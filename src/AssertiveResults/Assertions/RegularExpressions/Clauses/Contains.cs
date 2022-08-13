using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    internal sealed class Contains : IContains
    {
        private readonly Regex _regex;

        internal Contains(Regex regex)
        {
            _regex = regex;
        }

        public IResult LowerCase()
        {
            return _regex.Assert(RegexPattern.LowerCase,
                ErrorCode.Assertion.RegularExpression,
                ErrorDescription.StringMissingLowerCase);
        }

        public IResult UpperCase()
        {
            return _regex.Assert(RegexPattern.UpperCase,
                ErrorCode.Assertion.RegularExpression,
                ErrorDescription.StringMissingUpperCase);
        }

        public IResult Alphabet()
        {
            return _regex.Assert(RegexPattern.Alphabet,
                ErrorCode.Assertion.RegularExpression,
                ErrorDescription.StringMissingAlphabet);
        }

        public IResult Alphameric()
        {
            return _regex.Assert(RegexPattern.Alphameric,
                ErrorCode.Assertion.RegularExpression,
                ErrorDescription.StringMissingAlphameric);
        }

        public IResult Number()
        {
            return _regex.Assert(RegexPattern.Number,
                ErrorCode.Assertion.RegularExpression,
                ErrorDescription.StringMissingNumber);
        }

        public IResult Symbol()
        {
            return _regex.Assert(RegexPattern.Symbols,
                ErrorCode.Assertion.RegularExpression,
                ErrorDescription.StringMissingSpecialCharacter);
        }
    }
}