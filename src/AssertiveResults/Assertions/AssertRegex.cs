using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class AssertRegex : IAssertRegex, IRegex
    {
        private Assertion _assertion;
        private string _input;
        private bool _invalid;

        internal AssertRegex(Assertion assertion)
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

        internal Assertion Matches(string pattern, Error error)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _assertion.IsSatisfied = _invalid ? !isMatch : isMatch;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(error);

            return _assertion;
        }

        public IAssertion Pattern(string pattern)
        {
            var error = Error.Validation();
            return Matches(pattern, error);
        }
    }
}