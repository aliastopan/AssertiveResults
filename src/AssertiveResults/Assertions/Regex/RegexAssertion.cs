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

        public IRegexAssert MinLength(int min)
        {
            var pattern = string.Concat(@".{", min, @",}");
            var predicate = _invalid ? "must be less than" : "must be least";
            var errorCode = "Regex.Validation";
            var errorMessage = $"Input {predicate} {min} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Match(pattern, error);
        }

        public IRegexAssert MaxLength(int max)
        {
            var pattern = string.Concat(@"^.{1,", max, @"}$");
            var predicate = _invalid ? "must be more than" : "cannot be more than";
            var errorCode = "Regex.Validation";
            var errorMesage = $"Input {predicate} {max} characters.";
            var error = Error.Validation(errorCode, errorMesage);
            return Match(pattern, error);
        }

        public IRegexAssert Length(int min, int max)
        {
            var pattern = string.Concat(@"^.{", min, @",", max, @"}$");
            var errorCode = "Regex.Validation";
            var predicate = _invalid ? "must be more than" : $"must be between {min} and {max}";
            var errorMesage = $"Input {predicate} characters.";
            var error = Error.Validation(errorCode, errorMesage);
            return Match(pattern, error);
        }
    }
}