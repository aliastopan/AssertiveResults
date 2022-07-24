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

        public IRegexAssertion Matches(string input)
        {
            _input = input;
            _invalid = false;
            return this;
        }

        public IRegexAssertion Invalid(string input)
        {
            _input = input;
            _invalid = true;
            return this;
        }

        internal IRegexAssert Matches(string pattern, Error error)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _assertion.IsSatisfied = _invalid ? !isMatch : isMatch;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(error);

            return this;
        }

        public IRegexAssert Pattern(string pattern)
        {
            var errorCode = "Regex.Validation";
            var errorMessage = "Regex validation error has occured.";
            var error = Error.Validation(errorCode, errorMessage);
            return Matches(pattern, error);
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