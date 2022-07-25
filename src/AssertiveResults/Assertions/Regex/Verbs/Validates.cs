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
            _regexAssertion.MinLength(8).WithDefaultError("Password");
            _regexAssertion.Contains.LowerCase().WithDefaultError("Password");
            _regexAssertion.Contains.UpperCase().WithDefaultError("Password");
            _regexAssertion.Contains.Number().WithDefaultError("Password");
            return this;
        }

        public IValidatesAssert Email()
        {
            var pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            var errorCode = "Regex.Validation";
            var errorMesage = "Invalid email format.";
            var error = Error.Validation(errorCode, errorMesage);
            _regexAssertion.Match(pattern, error);
            return this;
        }
    }
}