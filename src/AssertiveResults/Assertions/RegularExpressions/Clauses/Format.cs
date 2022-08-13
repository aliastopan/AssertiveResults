using System;
using AssertiveResults.Errors;
using Strength = AssertiveResults.PasswordStrength;

namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    internal sealed class Format : IFormat
    {
        private readonly Regex _regex;

        internal Format(Regex regex)
        {
            _regex = regex;
        }

        public IResult Username(int min = 1, int max = 32)
        {
            if(min < 0 || max <= min) throw new InvalidOperationException();

            return _regex.Assert(RegexPattern.Username(min, max),
                "Username.Validation",
                "Invalid username format.");
        }

        public IResult StrongPassword(Strength strength = Strength.Standard)
        {
            string pattern;
            string errorDescription;

            switch(strength)
            {
                case Strength.Complex:
                    pattern = RegexPattern.Password.Complex;
                    errorDescription = "Password must contain 1 lowercase letter, 1 uppercase letter, 1 number, and be at least 8 characters long.";
                    break;
                case Strength.Maximum:
                    pattern = RegexPattern.Password.Maximum;
                    errorDescription = "Password must contain 1 lowercase letter, 1 uppercase letter, 1 number, 1 special character, and be at least 8 characters long.";
                    break;
                default:
                    pattern = RegexPattern.Password.Standard;
                    errorDescription = "Password must contain 1 lowercase letter, 1 number, and be at least 8 characters long.";
                    break;
            }

            return _regex.Assert(pattern,
                "PasswordStrength.Validation",
                errorDescription);
        }

        public IResult EmailAddress()
        {
            return _regex.Assert(RegexPattern.EmailAddress,
                "EmailAddress.Validation",
                "Invalid email address format.");
        }
    }
}