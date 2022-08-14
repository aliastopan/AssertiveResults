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
                ErrorTitle.Assertion.RegularExpression,
                ErrorDetail.StringMissingLowerCase);
        }

        public IResult UpperCase()
        {
            return _regex.Assert(RegexPattern.UpperCase,
                ErrorTitle.Assertion.RegularExpression,
                ErrorDetail.StringMissingUpperCase);
        }

        public IResult Alphabet()
        {
            return _regex.Assert(RegexPattern.Alphabet,
                ErrorTitle.Assertion.RegularExpression,
                ErrorDetail.StringMissingAlphabet);
        }

        public IResult Alphameric()
        {
            return _regex.Assert(RegexPattern.Alphameric,
                ErrorTitle.Assertion.RegularExpression,
                ErrorDetail.StringMissingAlphameric);
        }

        public IResult Number()
        {
            return _regex.Assert(RegexPattern.Number,
                ErrorTitle.Assertion.RegularExpression,
                ErrorDetail.StringMissingNumber);
        }

        public IResult Symbol()
        {
            return _regex.Assert(RegexPattern.Symbols,
                ErrorTitle.Assertion.RegularExpression,
                ErrorDetail.StringMissingSpecialCharacter);
        }
    }
}