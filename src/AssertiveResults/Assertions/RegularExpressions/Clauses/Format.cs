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
            if(min < 0 || max <= min)
            {
                throw new InvalidOperationException();
            }

            return _regex.Assert(RegexPattern.Username(min, max),
                ErrorTitle.Assertion.UsernameStandard,
                ErrorDetail.InvalidUsernameFormat);
        }

        public IResult StrongPassword(Strength strength = Strength.Standard)
        {
            switch(strength)
            {
                case Strength.Complex:
                {
                    return _regex.Assert(RegexPattern.Password.Complex,
                        ErrorTitle.Assertion.PasswordStrength,
                        ErrorDetail.WeakPasswordComplex);
                }
                case Strength.Maximum:
                {
                    return _regex.Assert(RegexPattern.Password.Maximum,
                        ErrorTitle.Assertion.PasswordStrength,
                        ErrorDetail.WeakPasswordComplex);
                }
                default:
                {
                    return _regex.Assert(RegexPattern.Password.Standard,
                        ErrorTitle.Assertion.PasswordStrength,
                        ErrorDetail.WeakPasswordComplex);
                }
            }
        }

        public IResult EmailAddress()
        {
            return _regex.Assert(RegexPattern.EmailAddress,
                ErrorTitle.Assertion.EmailAddressFormat,
                ErrorDetail.InvalidEmailAddressFormat);
        }
    }
}