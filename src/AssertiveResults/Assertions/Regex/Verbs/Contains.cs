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
            var predicate = _regexAssertion.isMustNot ? "not contain" : "contain";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"Input must {predicate} lower case character.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }

        public IRegexAssert UpperCase()
        {
            var pattern = @"[A-Z]+";
            var predicate = _regexAssertion.isMustNot ? "not contain" : "contain";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"Input must {predicate} upper case character.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }

        public IRegexAssert Alphabet()
        {
            var pattern = @"[a-zA-Z]+";
            var predicate = _regexAssertion.isMustNot ? "not contain" : "contain";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.DefaultArgument} must {predicate} alphabet.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }

        public IRegexAssert Alphameric()
        {
            var pattern = @"[a-zA-Z0-9]+";
            var predicate = _regexAssertion.isMustNot ? "not contain" : "contain";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.DefaultArgument} must {predicate} alphabet or number.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }

        public IRegexAssert Number()
        {
            var pattern = @"[0-9]+";
            var predicate = _regexAssertion.isMustNot ? "not contain" : "contain";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.DefaultArgument} must {predicate} number.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }

        public IRegexAssert Symbol()
        {
            var pattern = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
            var predicate = _regexAssertion.isMustNot ? "not contain" : "contain";
            var errorCode = $"{_regexAssertion.PrefixError}.Validation";
            var errorMesage = $"{_regexAssertion.DefaultArgument} must {predicate} symbol.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }
    }
}