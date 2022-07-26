using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex.Clauses
{
    public class Contains : IContains
    {
        private RegexAssertion _regexAssertion;

        internal Contains(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IRegexAssert LowerCase()
        {
            var pattern = Expression.LOWERCASE;
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"Input must contain lower case character.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert UpperCase()
        {
            var pattern = Expression.UPPERCASE;
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"Input must contain upper case character.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphabet()
        {
            var pattern = Expression.ALPHABET;
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.InputArgument} must contain alphabet.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphameric()
        {
            var pattern = Expression.ALPHAMERIC;
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.InputArgument} must contain alphabet or number.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Number()
        {
            var pattern = Expression.NUMBER;
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.InputArgument} must contain number.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Symbol()
        {
            var pattern = Expression.SYMBOL;
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.InputArgument} must contain symbol.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }
    }
}