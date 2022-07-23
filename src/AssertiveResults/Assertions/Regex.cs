using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Regex : IMatch
    {
        private Assertion _assertion;
        private string _input;
        private bool _invalid;

        internal Regex(Assertion assertion)
        {
            _assertion = assertion;
        }

        public IMatch Match(string input)
        {
            _input = input;
            _invalid = false;
            return this;
        }

        public IMatch Invalid(string input)
        {
            _input = input;
            _invalid = true;
            return this;
        }

        public IRegex SpecialCharacters()
        {
            var pattern = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
            var error = Error.Invalid();
            return Match(pattern, error);
        }

        internal Assertion Match(string pattern, Error error)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _assertion.IsSatisfied = _invalid ? !isMatch : isMatch;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(error);

            return _assertion;
        }
    }
}