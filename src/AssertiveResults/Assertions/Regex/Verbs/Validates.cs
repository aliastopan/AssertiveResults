using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex.Verbs
{
    public class Validates : IValidates, IValidatesAssert
    {
        private RegexAssertion _regexAssertion;

        internal Validates(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IValidatesAssert Username()
        {
            return this;
        }

        public IValidatesAssert PasswordStrength()
        {
            var pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            var errorCode = "PasswordStrength.Validation";
            var errorMesage = "Password must be at least 8 characters long and contain one uppercase and one lowercase character and a number.";
            var error = Error.Validation(errorCode, errorMesage);
            _regexAssertion.Match(pattern, error);
            return this;
        }

        public IValidatesAssert Email()
        {
            var pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            var errorCode = "Email.Validation";
            var errorMesage = "Invalid email address format.";
            var error = Error.Validation(errorCode, errorMesage);
            _regexAssertion.Match(pattern, error);
            return this;
        }
    }
}