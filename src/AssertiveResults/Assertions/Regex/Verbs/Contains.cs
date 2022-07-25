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
            var errorCode = "Regex.Validation";
            var errorMesage = $"Input must {predicate} lower case character.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }

        public IRegexAssert UpperCase()
        {
            var pattern = @"[A-Z]+";
            var predicate = _regexAssertion.isMustNot ? "not contain" : "contain";
            var errorCode = "Regex.Validation";
            var errorMesage = $"Input must {predicate} upper case character.";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }
    }
}