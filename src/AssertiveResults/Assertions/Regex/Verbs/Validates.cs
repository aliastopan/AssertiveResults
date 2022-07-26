using System;
using AssertiveResults.Errors;
using Strength = AssertiveResults.PasswordStrength;

namespace AssertiveResults.Assertions.Regex.Verbs
{
    public class Validates : IValidates
    {
        private RegexAssertion _regexAssertion;

        internal Validates(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IRegexAssert Username(int min = 1, int max = 32)
        {
            if(min < 0 || max <= min)
                throw new InvalidOperationException();

            var pattern = string.Concat(@"^(?=.{", min, @",", max, @"}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
            var errorCode = "Username.Validation";
            var errorDescription = "Invalid username format.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert PasswordStrength(PasswordStrength strength = Strength.Standard)
        {
            string pattern;
            string errorCode;
            string errorDescription;

            switch(strength)
            {
                case Strength.Complex:
                    pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
                    errorCode = "PasswordStrength.Complex.Validation";
                    errorDescription = "Password must contain 1 lowercase letter, 1 uppercase letter, 1 number, and be at least 8 characters long.";
                    break;
                case Strength.Maximum:
                    pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[~!@#$%^&*\-+=_(){}<>'"":;,.\/\[\]|\\?]).{8,}$";
                    errorCode = "PasswordStrength.Maximum.Validation";
                    errorDescription = "Password must contain 1 lowercase letter, 1 uppercase letter, 1 number, 1 special character, and be at least 8 characters long.";
                    break;
                default:
                    pattern = @"^(?=.*[a-z])(?=.*\d)[a-zA-Z\d]{8,}$";
                    errorCode = "PasswordStrength.Standard.Validation";
                    errorDescription = "Password must contain 1 lowercase letter, 1 number, and be at least 8 characters long.";
                    break;
            }

            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Email()
        {
            var pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            var errorCode = "Email.Validation";
            var errorDescription = "Invalid email address format.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }
    }
}