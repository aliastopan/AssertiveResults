using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex.Verbs
{
    public class Validates : IValidates
    {
        private RegexAssertion _regexAssertion;

        internal Validates(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IRegexAssert Username()
        {
            return _regexAssertion;
        }

        public IRegexAssert PasswordStrength()
        {
            var pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            var errorCode = "Regex.Validation";
            var errorMesage = $"{_regexAssertion.ArgName}";
            var error = Error.Validation(errorCode, errorMesage);
            return _regexAssertion.Match(pattern, error);
        }

        public IRegexAssert Email()
        {
            return _regexAssertion;
        }
    }
}