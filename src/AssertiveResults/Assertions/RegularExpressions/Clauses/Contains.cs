using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    public class Contains : IContains
    {
        private readonly RegexAssertion _regexAssertion;
        private readonly Assertation _assertation;

        internal Contains(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
            _assertation = _regexAssertion.assertation;
        }

        public IRegexAssert LowerCase()
        {
            var pattern = Expression.LOWERCASE;
            var errorCode = "LowerCase.Validation";
            var errorDescription = $"String must contain lower case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert UpperCase()
        {
            var pattern = Expression.UPPERCASE;
            var errorCode = "UpperCase.Validation";
            var errorDescription = $"String must contain upper case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphabet()
        {
            var pattern = Expression.ALPHABET;
            var errorCode = "Alphabet.Validation";
            var errorDescription = $"String must contain alphabet.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphameric()
        {
            var pattern = Expression.ALPHAMERIC;
            var errorCode = "Alphameric.Validation";
            var errorDescription = $"String must contain alphabet or number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Number()
        {
            var pattern = Expression.NUMBER;
            var errorCode = "Number.Validation";
            var errorDescription = $"String must contain number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Symbol()
        {
            var pattern = Expression.SYMBOL;
            var errorCode = "Symbol.Validation";
            var errorDescription = $"String must contain symbol.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }
    }
}