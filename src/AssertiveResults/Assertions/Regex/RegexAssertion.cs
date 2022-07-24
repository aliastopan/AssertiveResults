using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex
{
    public class RegexAssertion : IRegexAssertion, IRegexAssert, IRegex
    {
        private Assertation _assertion;
        private string _input;
        private bool _invalid;

        internal RegexAssertion(Assertation assertion)
        {
            _assertion = assertion;
        }

        public IRegexAssertion Must(string input)
        {
            _input = input;
            _invalid = false;
            return this;
        }

        public IRegexAssertion MustNot(string input)
        {
            _input = input;
            _invalid = true;
            return this;
        }

        internal IRegexAssert Match(RegularExpression regex, Error error)
        {
            var isMatch = regex.IsMatch(_input);
            _assertion.IsSatisfied = _invalid ? !isMatch : isMatch;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(error);

            return this;
        }

        internal IRegexAssert Match(string pattern, Error error)
        {
            var regex = new RegularExpression(pattern);
            return Match(regex, error);
        }

        public IRegexAssert Match(RegularExpression regex)
        {
            var errorCode = "Regex.Validation";
            var errorMessage = "Regex validation error has occured.";
            var error = Error.Validation(errorCode, errorMessage);
            return Match(regex, error);
        }

        public IRegexAssert Match(string pattern)
        {
            var regex = new RegularExpression(pattern);
            return Match(regex);
        }

        public IRegexAssertion WithError(Error error)
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