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
                ErrorCode.Assertion.UsernameStandard,
                ErrorDescription.InvalidUsernameFormat);
        }

        public IResult StrongPassword(Strength strength = Strength.Standard)
        {
            string pattern;
            string errorDescription;

            switch(strength)
            {
                case Strength.Complex:
                    pattern = RegexPattern.Password.Complex;
                    errorDescription = ErrorDescription.WeakPasswordComplex;
                    break;
                case Strength.Maximum:
                    pattern = RegexPattern.Password.Maximum;
                    errorDescription = ErrorDescription.WeakPasswordMaximum;
                    break;
                default:
                    pattern = RegexPattern.Password.Standard;
                    errorDescription = ErrorDescription.WeakPasswordStandard;
                    break;
            }

            return _regex.Assert(pattern,
                ErrorCode.Assertion.PasswordStrength,
                errorDescription);
        }

        public IResult EmailAddress()
        {
            return _regex.Assert(RegexPattern.EmailAddress,
                ErrorCode.Assertion.EmailAddressFormat,
                ErrorDescription.InvalidEmailAddressFormat);
        }
    }
}