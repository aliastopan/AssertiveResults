using System;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex.Verbs
{
    public class Validates : IValidates, IValidation
    {
        private RegexAssertion _regexAssertion;

        internal Validates(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IValidation Username(int min = 1, int max = 32)
        {
            if(min < 0 || max <= min)
                throw new InvalidOperationException();

            var pattern = string.Concat(@"^(?=.{", min, @",", max, @"}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
            var errorCode = "Username.Validation";
            var errorMesage = "Invalid username format.";
            var error = Error.Validation(errorCode, errorMesage);
            _regexAssertion.Regex(pattern, error);
            return this;
        }

        public IValidation PasswordStrength()
        {
            var pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            var errorCode = "PasswordStrength.Validation";
            var errorMesage = "Password must be at least 8 characters long and contain one uppercase and one lowercase character and a number.";
            var error = Error.Validation(errorCode, errorMesage);
            _regexAssertion.Regex(pattern, error);
            return this;
        }

        public IValidation Email()
        {
            var pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            var errorCode = "Email.Validation";
            var errorMesage = "Invalid email address format.";
            var error = Error.Validation(errorCode, errorMesage);
            _regexAssertion.Regex(pattern, error);
            return this;
        }
    }
}