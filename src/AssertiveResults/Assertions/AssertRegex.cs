using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class AssertRegex : IAssertRegex, IRegexMatch, IRegexInvalid
    {
        private Assertion _assertion;
        private string _input;
        private bool _invalid;

        internal AssertRegex(Assertion assertion)
        {
            _assertion = assertion;
        }

        public IRegexMatch Match(string input)
        {
            _input = input;
            _invalid = false;
            return this;
        }

        public IRegexInvalid Invalid(string input)
        {
            _input = input;
            _invalid = true;
            return this;
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

        public IAssertion MinLength(int min)
        {
            var pattern = string.Concat(@".{", min, @",}");
            var error = Error.Invalid(message: $"Regex: must have at least {min} characters");
            return Match(pattern, error);
        }

        public IAssertion MaxLength(int max)
        {
            var pattern = string.Concat(@"^.{1,", max, @"}$");
            var error = Error.Invalid(message: $"Regex: must not exceed {max} characters");
            return Match(pattern, error);
        }

        public IAssertion Length(int min, int max)
        {
            var pattern = string.Concat(@"^.{", min, @",", max, @"}$");
            var error = Error.Invalid(message: $"Regex: length must be between {min} to {max} characters");
            return Match(pattern, error);
        }

        public IAssertion NumericCharacters()
        {
            var pattern = @"[0-9]+";
            var predicate = _invalid ? "not have" : "have";
            var error = Error.Invalid(message: $"Regex: must {predicate} numeric character");
            return Match(pattern, error);
        }

        public IAssertion LowerCaseCharacters()
        {
            var pattern = @"[a-z]+";
            var predicate = _invalid ? "not have" : "have";
            var error = Error.Invalid(message: $"Regex: must {predicate} lower case character");
            return Match(pattern, error);
        }

        public IAssertion UpperCaseCharacters()
        {
            var pattern = @"[A-Z]+";
            var predicate = _invalid ? "not have" : "have";
            var error = Error.Invalid(message: $"Regex: must {predicate} upper case character");
            return Match(pattern, error);
        }

        public IAssertion SpecialCharacters()
        {
            var pattern = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
            var predicate = _invalid ? "not have" : "have";
            var error = Error.Invalid(message: $"Regex: must {predicate} special character");
            return Match(pattern, error);
        }

        public IAssertion Pattern(string pattern)
        {
            var error = Error.Invalid();
            return Match(pattern, error);
        }
    }
}