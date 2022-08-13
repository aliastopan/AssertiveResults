using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    internal sealed class Contains : IContains
    {
        private readonly Regex _regex;

        internal Contains(Regex regex)
        {
            _regex = regex;
        }

        public IResult LowerCase()
        {
            const string pattern = RegexPattern.LowerCase;
            const string errorCode = "LowerCase.Validation";
            const string errorDescription = "String must contain lower case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regex.PatternMatching(pattern, error);
        }

        public IResult UpperCase()
        {
            const string pattern = RegexPattern.UpperCase;
            const string errorCode = "UpperCase.Validation";
            const string errorDescription = "String must contain upper case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regex.PatternMatching(pattern, error);
        }

        public IResult Alphabet()
        {
            const string pattern = RegexPattern.Alphabet;
            const string errorCode = "Alphabet.Validation";
            const string errorDescription = "String must contain alphabet.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regex.PatternMatching(pattern, error);
        }

        public IResult Alphameric()
        {
            const string pattern = RegexPattern.Alphameric;
            const string errorCode = "Alphameric.Validation";
            const string errorDescription = "String must contain alphabet or number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regex.PatternMatching(pattern, error);
        }

        public IResult Number()
        {
            const string pattern = RegexPattern.Number;
            const string errorCode = "Number.Validation";
            const string errorDescription = "String must contain number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regex.PatternMatching(pattern, error);
        }

        public IResult Symbol()
        {
            const string pattern = RegexPattern.Symbols;
            const string errorCode = "Symbol.Validation";
            const string errorDescription = "String must contain symbol.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regex.PatternMatching(pattern, error);
        }
    }
}