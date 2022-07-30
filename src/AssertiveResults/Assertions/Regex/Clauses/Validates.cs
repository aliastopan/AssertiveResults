using System;
using AssertiveResults.Errors;
using Strength = AssertiveResults.PasswordStrength;

namespace AssertiveResults.Assertions.Regex.Clauses
{
    public class Validates : IValidates
    {
        private readonly RegexAssertion _regexAssertion;

        internal Validates(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IRegexAssert Username(int min = 1, int max = 32)
        {
            if(min < 0 || max <= min)
                throw new InvalidOperationException();

            var pattern = Expression.Username(min, max);
            var errorCode = "Username.Validation";
            var errorDescription = "Invalid username format.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert PasswordStrength(PasswordStrength strength = Strength.Standard)
        {
            string pattern;
            string errorDescription;

            switch(strength)
            {
                case Strength.Complex:
                    pattern = Expression.Password.Complex();
                    errorDescription = "Password must contain 1 lowercase letter, 1 uppercase letter, 1 number, and be at least 8 characters long.";
                    break;
                case Strength.Maximum:
                    pattern = Expression.Password.Maximum();
                    errorDescription = "Password must contain 1 lowercase letter, 1 uppercase letter, 1 number, 1 special character, and be at least 8 characters long.";
                    break;
                default:
                    pattern = Expression.Password.Standard();
                    errorDescription = "Password must contain 1 lowercase letter, 1 number, and be at least 8 characters long.";
                    break;
            }

            var errorCode = "PasswordStrength.Validation";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }

        public IRegexAssert Email()
        {
            var pattern = Expression.Email();
            var errorCode = "Email.Validation";
            var errorDescription = "Invalid email address format.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.Regex(pattern, error);
        }
    }
}