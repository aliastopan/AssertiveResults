using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    public class Contains : IContains
    {
        private readonly RegexAssertion _regexAssertion;

        internal Contains(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IRegexAssert LowerCase()
        {
            const string pattern = Expression.LOWERCASE;
            const string errorCode = "LowerCase.Validation";
            const string errorDescription = "String must contain lower case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert UpperCase()
        {
            const string pattern = Expression.UPPERCASE;
            const string errorCode = "UpperCase.Validation";
            const string errorDescription = "String must contain upper case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphabet()
        {
            const string pattern = Expression.ALPHABET;
            const string errorCode = "Alphabet.Validation";
            const string errorDescription = "String must contain alphabet.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphameric()
        {
            const string pattern = Expression.ALPHAMERIC;
            const string errorCode = "Alphameric.Validation";
            const string errorDescription = "String must contain alphabet or number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Number()
        {
            const string pattern = Expression.NUMBER;
            const string errorCode = "Number.Validation";
            const string errorDescription = "String must contain number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Symbol()
        {
            const string pattern = Expression.SYMBOL;
            const string errorCode = "Symbol.Validation";
            const string errorDescription = "String must contain symbol.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }
    }
}