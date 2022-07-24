using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.Regex.Verbs;

namespace AssertiveResults.Assertions.Regex
{
    public class RegexAssertion : IRegexAssertion, IMust, IMustNot, IRegexAssert, IRegex
    {
        private Assertation _assertion;
        private string _input;
        private bool _invalid;

        public IContains Contains { get; internal set; }

        internal RegexAssertion(Assertation assertion)
        {
            _assertion = assertion;
            Contains = new Contains(this);
        }

        public IMust Must(string input)
        {
            _input = input;
            _invalid = false;
            return this;
        }

        public IMustNot MustNot(string input)
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

        public IRegexAssert MinLength(int min)
        {
            var pattern = string.Concat(@".{", min, @",}");
            var errorCode = "Regex.Validation";
            var errorMessage = $"Input must be least {min} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Match(pattern, error);
        }

        public IRegexAssert MaxLength(int max)
        {
            var pattern = string.Concat(@"^.{1,", max, @"}$");
            var errorCode = "Regex.Validation";
            var errorMesage = $"Input cannot be more than {max} characters.";
            var error = Error.Validation(errorCode, errorMesage);
            return Match(pattern, error);
        }

        public IRegexAssert Length(int min, int max)
        {
            var pattern = string.Concat(@"^.{", min, @",", max, @"}$");
            var errorCode = "Regex.Validation";
            var errorMesage = $"Input must be between {min} and {max} characters.";
            var error = Error.Validation(errorCode, errorMesage);
            return Match(pattern, error);
        }
    }
}