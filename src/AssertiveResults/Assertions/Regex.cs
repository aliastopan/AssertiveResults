using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Regex : IMatch
    {
        private Assertion _assertion;

        internal Regex(Assertion assertion)
        {
            _assertion = assertion;
        }

        internal string Input { get; set; }

        public IMatch Match(string input)
        {
            Input = input;
            return this;
        }

        public IRegex SpecialCharacters()
        {
            string pattern = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
            return Matching(pattern);
        }

        internal Assertion Matching(string pattern)
        {
            var regex = new RegularExpression(pattern);
            _assertion.IsSatisfied = regex.IsMatch(Input);
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        internal Assertion NotMatching(string pattern)
        {
            var regex = new RegularExpression(pattern);
            _assertion.IsSatisfied = !regex.IsMatch(Input);
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }
    }
}