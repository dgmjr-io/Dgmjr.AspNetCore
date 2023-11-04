using Microsoft.Net.Http.Headers;
using Vogen;

namespace Dgmjr.Payloads
{
    /// <summary>Indicates the part of a resultset that the server should return.  It's a zero-based index from the start to the end if the desired resultset.  The format is \"items {start}-{end}\".  If the end is omitted, the server will return all items from the start to the end of the resultset.  If the start is omitted, the server will return all items from the beginning to the end of the resultset.  If both are omitted, the server will return all items in the resultset.  The server will return a 416 (Range Not Satisfiable) if the requested range is not satisfiable.</summary>
    /// <default>items 0-<inheritdoc cref="MaxIntString" path="/value/text()" /></default>
    [ValueObject(
        typeof(System.Range),
        conversions: Conversions.SystemTextJson | Conversions.TypeConverter
    )]
    public readonly partial record struct Range
    {
        /// <value><inheritdoc cref="Items" path="/value" /> 0-*</value>
        public const string AllString = $"{Items} 0-*";

        /// <inheritdoc cref="AllString" path="/value" />
        public static readonly Range All = Parse(AllString);

        /// <value>items</value>
        public const string Items = "items";

        /// <value>bytes</value>
        public const string Bytes = "bytes";

        /// <value>records</value>
        public const string Records = "records";

        /// <value>^(?&x3c;Units&x3e;(?:item)|(?:byte)s)\s*(?&x3c;Start&x3e;[0-9]+)\-(?:(?&x3c;End&x3e;[0-9]+)?|[\*])$</value>
        public const string RegexString =
            @"^(?<Units>(?:item)|(?:byte)s)\s*(?<Start>[0-9]+)\-(?:(?<End>[0-9]+)?|[\*])$";

        public Units Units =>
            Regex().Match(Value.ToString()).Groups[nameof(Units)].Value switch
            {
                Items => Units.Items,
                Records => Units.Records,
                Bytes => Units.Bytes,
                _ => Units.Bytes
            };

#if NET7_0_OR_GREATER
        /// <inheritdoc cref="RegexString" />
        [GeneratedRegex(RegexString, Rxo.Compiled | Rxo.IgnoreCase)]
        public static partial Regex Regex();
#else
        private static readonly Regex _regex = new(RegexString, Rxo.Compiled | Rxo.IgnoreCase);

        /// <inheritdoc cref="RegexString" />
        public static Regex Regex() => _regex;
#endif

        /// <value>2147483647</value>
        private const string MaxIntString = "2147483647";

        public int PageNumber
        {
            get
            {
                try
                {
                    EnsureInitialized();
                }
                catch
                {
                    return 1;
                }
                return (Value.Start.Value / PageSize) + 1;
            }
        }
        public int PageSize
        {
            get
            {
                try
                {
                    EnsureInitialized();
                }
                catch
                {
                    return int.MaxValue;
                }
                return Value.End.Value - Value.Start.Value;
            }
        }
        public int Start
        {
            get
            {
                try
                {
                    EnsureInitialized();
                }
                catch
                {
                    return 0;
                }
                return Value.Start.Value;
            }
        }
        public int End
        {
            get
            {
                try
                {
                    EnsureInitialized();
                }
                catch
                {
                    return int.MaxValue;
                }
                return Value.End.Value;
            }
        }

        public static Range From(int pageNumber, int pageSize = int.MaxValue)
        {
            return From(
                new System.Range(
                    new((pageNumber - 1) * pageSize),
                    new Index(pageSize + (pageNumber - 1) * pageSize, false)
                )
            );
        }

        public static Range Parse(string input)
        {
            var match = Regex().Match(input);
            if (!match.Success)
                throw new ArgumentException("Invalid range request.", nameof(input));
            return From(
                new System.Range(
                    new Index(int.Parse(match.Groups[nameof(Start)].Value)),
                    new Index(
                        int.Parse(
                            match.Groups[nameof(End)].Value == "*"
                                ? MaxIntString
                                : match.Groups[nameof(End)].Value ?? MaxIntString
                        ),
                        false
                    )
                )
            );
        }

        public static Range From(RangeItemHeaderValue rangeHeader)
        {
            return From(
                new System.Range(
                    new Index((int)rangeHeader.From!.Value),
                    new Index((int)rangeHeader.To!.Value, false)
                )
            );
        }

        public static Validation Validate(System.Range input)
        {
            return input.Start.Value >= 0 && input.End.Value > input.Start.Value
                ? Validation.Ok
                : Validation.Invalid("Range must be positive and start must be less than end.");
        }

        internal static bool TryParse(string? range, out Range rangeRequest)
        {
            try
            {
                rangeRequest = Parse(range);
                return true;
            }
            catch
            {
                rangeRequest = All;
                return false;
            }
        }
    }

    public enum Units
    {
        None = 0,
        Bytes = 1,
        Items = 2,
        Records = 4
    }
}
