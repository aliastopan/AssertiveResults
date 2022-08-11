using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    internal sealed class Contains : IContains
    {
        private readonly Regex _regexAssertion;

        internal Contains(Regex regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IResult LowerCase()
        {
            const string pattern = Expression.LowerCase;
            const string errorCode = "LowerCase.Validation";
            const string errorDescription = "String must contain lower case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }

        public IResult UpperCase()
        {
            const string pattern = Expression.UpperCase;
            const string errorCode = "UpperCase.Validation";
            const string errorDescription = "String must contain upper case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }

        public IResult Alphabet()
        {
            const string pattern = Expression.Alphabet;
            const string errorCode = "Alphabet.Validation";
            const string errorDescription = "String must contain alphabet.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }

        public IResult Alphameric()
        {
            const string pattern = Expression.Alphameric;
            const string errorCode = "Alphameric.Validation";
            const string errorDescription = "String must contain alphabet or number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }

        public IResult Number()
        {
            const string pattern = Expression.Number;
            const string errorCode = "Number.Validation";
            const string errorDescription = "String must contain number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }

        public IResult Symbol()
        {
            const string pattern = Expression.Symbols;
            const string errorCode = "Symbol.Validation";
            const string errorDescription = "String must contain symbol.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }
    }
}