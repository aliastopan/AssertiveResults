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

        public IRegexAssertValidates Username()
        {
            return _regexAssertion;
        }

        public IRegexAssertValidates PasswordStrength()
        {
            var pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            var errorCode = "Password.Validation";
            var errorMesage = "Password must be at least 8 characters long and contain one uppercase and one lowercase character and a number.";
            var error = Error.Validation(errorCode, errorMesage);
            return (IRegexAssertValidates) _regexAssertion.Match(pattern, error);
        }

        public IRegexAssertValidates Email()
        {
            return _regexAssertion;
        }
    }
}