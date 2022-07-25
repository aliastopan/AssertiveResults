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
            _regexAssertion.MinLength(8).WithArgName("Password");
            _regexAssertion.Contains.LowerCase().WithArgName("Password");
            _regexAssertion.Contains.UpperCase().WithArgName("Password");
            _regexAssertion.Contains.Number().WithArgName("Password");
            return _regexAssertion;
        }

        public IRegexAssertValidates Email()
        {
            var pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            var errorCode = "Regex.Validation";
            var errorMesage = "Invalid email format.";
            var error = Error.Validation(errorCode, errorMesage);
            return (IRegexAssertValidates) _regexAssertion.Match(pattern, error);
        }
    }
}