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
                "LowerCase.Validation",
                "String must contain lower case character.");
        }

        public IResult UpperCase()
        {
            return _regex.Assert(RegexPattern.UpperCase,
                "UpperCase.Validation",
                "String must contain upper case character.");
        }

        public IResult Alphabet()
        {
            return _regex.Assert(RegexPattern.Alphabet,
                "Alphabet.Validation",
                "String must contain alphabet.");
        }

        public IResult Alphameric()
        {
            return _regex.Assert(RegexPattern.Alphameric,
                "Alphameric.Validation",
                "String must contain alphabet or number.");
        }

        public IResult Number()
        {
            return _regex.Assert(RegexPattern.Number,
                "Number.Validation",
                "String must contain number.");
        }

        public IResult Symbol()
        {
            return _regex.Assert(RegexPattern.Symbols,
                "Symbol.Validation",
                "String must contain symbol.");
        }
    }
}