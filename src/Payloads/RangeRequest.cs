using System.Runtime.InteropServices;

using Microsoft.Extensions.Configuration;
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
    [StructLayout(LayoutKind.Auto)]
    public readonly partial record struct Range : IRegexValueObject<Range>
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

        public const string ExampleString = "items 0-10";
        public const string EmptyString = "items 0-0";
        public const string UriPrefix = "https://dgmjr.io/range";
        public const string UriFormatString = "https://dgmjr.io/range/{0}/{1}-{2}";

        /// <value>^(?&x3c;Units&x3e;(?:item)|(?:byte)s)\s*(?&x3c;Start&x3e;[0-9]+)\-(?:(?&x3c;End&x3e;[0-9]+)?|[\*])$</value>
        public const string RegexString =
            @"^(?<Units>(?:(?:item)|(?:byte))s)\s*(?<Start>[0-9]+)\-(?:(?<End>[0-9]+)?|[\*])$";

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

        public static Range From(RangeItemHeaderValue rangeHeader)
        {
            return From(
                new System.Range(
                    new Index((int)rangeHeader.From!.Value),
                    new Index((int)rangeHeader.To!.Value, false)
                )
            );
        }

        public static Range From(string value) => Parse(value);

        public static Range From(int pageNumber, int pageSize = int.MaxValue)
        {
            return From(
                new System.Range(
                    new((pageNumber - 1) * pageSize),
                    new Index(pageSize + (pageNumber - 1) * pageSize, false)
                )
            ) with
            {
                OriginalString = $"{Items} {pageNumber}-{pageSize}"
            };
        }

        public readonly string OriginalString { get; init; } = string.Empty;
        readonly string IRegexValueObject<Range>.Value => $"{Units} {Start}-{End}";
        readonly bool IRegexValueObject<Range>.IsEmpty =>
            Value.Start.Value == 0 && Value.End.Value == 0;

#if NET6_0_OR_GREATER
        static string IRegexValueObject<Range>.RegexString => RegexString;
        static string IRegexValueObject<Range>.Description => "Requested range of values to return";
        static Range IRegexValueObject<Range>.ExampleValue => From(ExampleString);
        static Range IRegexValueObject<Range>.Empty => From(EmptyString);
        Uri IHaveAUri.Uri => Uri;
#endif

        public int CompareTo(Range other) => Value.Start.Value.CompareTo(other.Value.Start.Value);

        public int CompareTo(object? obj) => obj is Range other ? CompareTo(other) : -1;

        public uri Uri => new(string.Format(UriFormatString, Units, Start, End));

        public static Range Parse(string value)
        {
            var match = Regex().Match(value);
            if (!match.Success)
                throw new ArgumentException("Invalid range request.", nameof(value));
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

        public static Validation Validate(System.Range input)
        {
            return input.Start.Value >= 0 && input.End.Value > input.Start.Value
                ? Validation.Ok
                : Validation.Invalid("Range must be positive and start must be less than end.");
        }

        public static Range Parse(string? range, IFormatProvider? provider) => Parse(range);

        public static bool TryParse(
            string? range,
            IFormatProvider? provider,
            out Range rangeRequest
        ) => TryParse(range, out rangeRequest);

        public static bool TryParse(string? range, out Range rangeRequest)
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
