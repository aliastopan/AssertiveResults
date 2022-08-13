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
            var errorCode = "Regex.Validation";
            var errorDescription = $"String doesn't match with the given {pattern} expression.";
            var error = Error.Validation(errorCode, errorDescription);
            return PatternMatching(pattern, error);
        }

        public IResult MatchesIllegal(string pattern)
        {
            var errorCode = "Regex.Validation";
            var errorDescription = $"String match with the given illegal {pattern} expression.";
            var error = Error.Validation(errorCode, errorDescription);
            return PatternMatching(pattern, error, illegal: true);
        }

        public IResult Length(int min, int max)
        {
            var pattern = RegexPattern.Length(min, max);
            var errorCode = "Length.Validation";
            var errorDescription = $"String must be between {min} and {max} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return PatternMatching(pattern, error);
        }

        public IResult MinLength(int min)
        {
            var pattern = RegexPattern.MinLength(min);
            var errorCode = "MinLength.Validation";
            var errorDescription = $"String must be least {min} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return PatternMatching(pattern, error);
        }

        public IResult MaxLength(int max)
        {
            var pattern = RegexPattern.MaxLength(max);
            var errorCode = "MaxLength.Validation";
            var errorDescription = $"String cannot be more than {max} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return PatternMatching(pattern, error);
        }

        public IMatch WithError(Error error)
        {
            _context.WithError(error);
            return this;
        }

        internal IResult PatternMatching(string pattern, Error error, bool illegal = false)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _context.AllCorrect = illegal ? !isMatch : isMatch;
            if(!_context.AllCorrect)
                _context.Errors.Add(error);

            return this;
        }
    }
}