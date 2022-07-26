using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex.Verbs
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
            var pattern = @"[a-z]+";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"Input must contain lower case character.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert UpperCase()
        {
            var pattern = @"[A-Z]+";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"Input must contain upper case character.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphabet()
        {
            var pattern = @"[a-zA-Z]+";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.InputArgument} must contain alphabet.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Alphameric()
        {
            var pattern = @"[a-zA-Z0-9]+";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.InputArgument} must contain alphabet or number.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Number()
        {
            var pattern = @"[0-9]+";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.InputArgument} must contain number.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Symbol()
        {
            var pattern = @"[~!@#$%^&*\-+=_(){}<>'"":;,.\/\[\]|\\?]+";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.InputArgument} must contain symbol.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Regex(pattern, error);
        }
    }
}