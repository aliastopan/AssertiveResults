using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class AssertRegex : IAssertRegex, IRegex, IRegexMatch
    {
        private Assertation _assertion;
        private string _input;
        private bool _invalid;

        internal AssertRegex(Assertation assertion)
        {
            _assertion = assertion;
        }

        public IRegex Matches(string input)
        {
            _input = input;
            _invalid = false;
            return this;
        }

        public IRegex Invalid(string input)
        {
            _input = input;
            _invalid = true;
            return this;
        }

        internal IRegexMatch Matches(string pattern, Error error)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _assertion.IsSatisfied = _invalid ? !isMatch : isMatch;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(error);

            return this;
        }

        public IRegexMatch Pattern(string pattern)
        {
            var errorCode = "Regex.Validation";
            var errorMessage = "Regex validation error has occured";
            var error = Error.Validation(errorCode, errorMessage);
            return Matches(pattern, error);
        }

        public IRegex WithError(Error error)
        {
            if(!_assertion.IsSatisfied)
            {
                _assertion.Errors.RemoveAt(_assertion.Errors.Count - 1);
                _assertion.Errors.Add(error);
            }

            return this;
        }
    }
}