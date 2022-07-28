using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex.Clauses
{
    public class Contains : IContains
    {
        private RegexAssertion _regexAssertion;
        private Assertation _assertation;

        internal Contains(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
            _assertation = _regexAssertion.assertation;
        }

        public IRegexAssert LowerCase()
        {
            var pattern = Expression.LOWERCASE;
            var errorCode = $"{_assertation.InputName}.LowerCase.Validation";
            var errorDescription = $"{_assertation.InputName} must contain lower case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert UpperCase()
        {
            var pattern = Expression.UPPERCASE;
            var errorCode = $"{_assertation.InputName}.UpperCase.Validation";
            var errorDescription = $"{_assertation.InputName} must contain upper case character.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphabet()
        {
            var pattern = Expression.ALPHABET;
            var errorCode = $"{_assertation.InputName}.Alphabet.Validation";
            var errorDescription = $"{_assertation.InputName} must contain alphabet.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphameric()
        {
            var pattern = Expression.ALPHAMERIC;
            var errorCode = $"{_assertation.InputName}.Alphameric.Validation";
            var errorDescription = $"{_assertation.InputName} must contain alphabet or number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Number()
        {
            var pattern = Expression.NUMBER;
            var errorCode = $"{_assertation.InputName}.Number.Validation";
            var errorDescription = $"{_assertation.InputName} must contain number.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Symbol()
        {
            var pattern = Expression.SYMBOL;
            var errorCode = $"{_assertation.InputName}.Symbol.Validation";
            var errorDescription = $"{_assertation.InputName} must contain symbol.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }
    }
}