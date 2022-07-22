using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Regex
    {
        private Assertion _assertion;

        internal Regex(Assertion assertion)
        {
            _assertion = assertion;
        }

        public Assertion Match(string input, RegularExpression regex)
        {
            _assertion.IsSatisfied = regex.IsMatch(input);
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public Assertion Match(string input, string pattern)
        {
            var regex = new RegularExpression(pattern);
            return Match(input, regex);
        }

        public Assertion NotMatch(string input, RegularExpression regex)
        {
            _assertion.IsSatisfied = !regex.IsMatch(input);
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public Assertion NotMatch(string input, string pattern)
        {
            var regex = new RegularExpression(pattern);
            return NotMatch(input, regex);
        }
    }
}