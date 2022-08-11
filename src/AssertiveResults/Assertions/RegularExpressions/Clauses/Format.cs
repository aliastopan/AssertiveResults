using System;
using AssertiveResults.Errors;
using Strength = AssertiveResults.PasswordStrength;

namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    internal sealed class Format : IFormat
    {
        private readonly Regex _regexAssertion;

        internal Format(Regex regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IResult Username(int min = 1, int max = 32)
        {
            if(min < 0 || max <= min)
                throw new InvalidOperationException();

            string pattern = Expression.Username(min, max);
            const string errorCode = "Username.Validation";
            const string errorDescription = "Invalid username format.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }

        public IResult StrongPassword(PasswordStrength strength = Strength.Standard)
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

            const string errorCode = "PasswordStrength.Validation";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }

        public IResult EmailAddress()
        {
            string pattern = Expression.Email();
            const string errorCode = "Email.Validation";
            const string errorDescription = "Invalid email address format.";
            var error = Error.Validation(errorCode, errorDescription);
            return _regexAssertion.PatternMatching(pattern, error);
        }
    }
}