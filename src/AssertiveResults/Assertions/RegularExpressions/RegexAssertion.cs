using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Assertions.RegularExpressions.Clauses;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions
{
    internal sealed class RegexAssertion : IRegexAssertion, IRegex, IRegexAssert
    {
        private readonly Context _context;
        private string _input;

        internal RegexAssertion(Context context)
        {
            this._context = context;
            Contains = new Contains(this);
            Format = new Format(this);
        }

        public IContains Contains { get; internal set; }
        public IFormat Format { get; internal set; }

        public IRegexAssertion Validate(string input)
        {
            _input = input;
            return this;
        }

        public IRegexAssert Matches(string pattern)
        {
            var errorCode = "Regex.Validation";
            var errorDescription = $"String doesn't match with the given {pattern} expression.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert MatchesIllegal(string pattern)
        {
            var errorCode = "Regex.Validation";
            var errorDescription = $"String match with the given illegal {pattern} expression.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error, illegal: true);
        }

        public IRegexAssert Length(int min, int max)
        {
            var pattern = Expression.Length(min, max);
            var errorCode = "Length.Validation";
            var errorDescription = $"String must be between {min} and {max} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert MinLength(int min)
        {
            var pattern = Expression.MinLength(min);
            var errorCode = "MinLength.Validation";
            var errorDescription = $"String must be least {min} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert MaxLength(int max)
        {
            var pattern = Expression.MaxLength(max);
            var errorCode = "MaxLength.Validation";
            var errorDescription = $"String cannot be more than {max} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssertion WithError(Error error)
        {
            if(_context.Failed)
            {
                _context.Errors.RemoveAt(_context.Errors.Count - 1);
                _context.Errors.Add(error);
            }

            return this;
        }

        internal IRegexAssert Regex(string pattern, Error error, bool illegal = false)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _context.IsSatisfied = illegal ? !isMatch : isMatch;
            if(!_context.IsSatisfied)
                _context.Errors.Add(error);

            return this;
        }
    }
}