using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Assertions.RegularExpressions.Clauses;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions
{
    internal sealed class Regex : IRegex, IMatch, IResult
    {
        private readonly Context _context;
        private string _input;

        internal Regex(Context context)
        {
            this._context = context;
            Contains = new Contains(this);
            Format = new Format(this);
        }

        public IContains Contains { get; internal set; }
        public IFormat Format { get; internal set; }

        public IMatch Validate(string input)
        {
            _input = input;
            return this;
        }

        public IResult Matches(string pattern)
        {
            return Assert(pattern,
                ErrorTitle.Assertion.RegularExpression,
                string.Format(ErrorDetail.StringNotMatchesRegularExpression, pattern));
        }

        public IResult MatchesIllegal(string pattern)
        {
            return Assert(pattern,
                ErrorTitle.Assertion.RegularExpression,
                string.Format(ErrorDetail.StringMatchesIllegalRegularExpression, pattern),
                illegal: true);
        }

        public IResult Length(int min, int max)
        {
            return Assert(RegexPattern.Length(min, max),
                ErrorTitle.Assertion.RegularExpression,
                string.Format(ErrorDetail.StringInvalidLength, min, max));
        }

        public IResult MinLength(int min)
        {
            return Assert(RegexPattern.MinLength(min),
                ErrorTitle.Assertion.RegularExpression,
                string.Format(ErrorDetail.StringTooShort, min));
        }

        public IResult MaxLength(int max)
        {
            return Assert(RegexPattern.MaxLength(max),
                ErrorTitle.Assertion.RegularExpression,
                string.Format(ErrorDetail.StringTooLong, max));
        }

        public IMatch WithError(IError error)
        {
            _context.WithError(error);
            return this;
        }

        public IMatch WithError(IError error, params object[] args)
        {
            _context.WithError(Error.FormatDetail(error, args));
            return this;
        }

        internal IResult Assert(
            string pattern,
            string errorTitle,
            string errorDetail,
            bool illegal = false)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _context.AllCorrect = illegal ? !isMatch : isMatch;
            if(_context.AllCorrect)
            {
                return this;
            }

            _context.Errors.Add(Error.Validation(errorTitle, errorDetail));
            return this;
        }
    }
}