using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Assertions.RegularExpressions.Clauses;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions
{
    internal sealed class Regex : IRegex, IMatch, IResult
    {
        private readonly Context _context;
        private string _input;

        internal Regex(Context context)
        {
            this._context = context;
            Contains = new Contains(this);
            Format = new Format(this);
        }

        public IContains Contains { get; internal set; }
        public IFormat Format { get; internal set; }

        public IMatch Validate(string input)
        {
            _input = input;
            return this;
        }

        public IResult Matches(string pattern)
        {
            return Assert(pattern,
                "Regex.Validation",
                string.Format("String doesn't match with the given {0} expression.", pattern));
        }

        public IResult MatchesIllegal(string pattern)
        {
            return Assert(pattern,
                "Regex.Validation",
                string.Format("String match with the given illegal {0} expression.", pattern),
                illegal: true);
        }

        public IResult Length(int min, int max)
        {
            return Assert(RegexPattern.Length(min, max),
                "Regex.Validation",
                string.Format("String must be between {0} and {1} characters.", min, max));
        }

        public IResult MinLength(int min)
        {
            return Assert(RegexPattern.MinLength(min),
                "Regex.Validation",
                string.Format("String must be least {0} characters.", min));
        }

        public IResult MaxLength(int max)
        {
            return Assert(RegexPattern.MaxLength(max),
                "Regex.Validation",
                string.Format("String cannot be more than {0} characters.", max));
        }

        public IMatch WithError(Error error)
        {
            _context.WithError(error);
            return this;
        }

        internal IResult Assert(
            string pattern,
            string errorCode,
            string errorMessages,
            bool illegal = false)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _context.AllCorrect = illegal ? !isMatch : isMatch;
            if(_context.AllCorrect)
                return this;

            _context.Errors.Add(Error.Validation(errorCode, errorMessages));
            return this;
        }
    }
}