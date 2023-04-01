using Microsoft.Net.Http.Headers;
using Vogen;

namespace Dgmjr.Payloads
{
    [ValueObject(
        typeof(System.Range),
        conversions: Conversions.SystemTextJson | Conversions.TypeConverter
    )]
    public partial record struct Range
    {
        public const string AllString = $"{Items} 0-*";
        public static readonly Range All = Parse(AllString);
        public const string Items = "items";
        public const string RegexString = @"items\s(?<Start>[0-9]+)\-(?:(?<End>[0-9]+)?|[\*])";

        [GeneratedRegex(RegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public static partial REx Regex();

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
}
