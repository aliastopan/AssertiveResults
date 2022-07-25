using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.Regex.Verbs;

namespace AssertiveResults.Assertions.Regex
{
    public class RegexAssertion : IRegexAssertion, IMust, IMustNot, IRegex, IRegexAssert, IRegexAssertValidates
    {
        internal bool isMustNot;
        private Assertation _assertion;
        private string _argument;
        private string _input;

        public IContains Contains { get; internal set; }
        public IValidates Validates { get; internal set; }
        internal string PrefixError => "Regex";
        internal string DefaultArgument = "Input";
        internal string Argument => string.IsNullOrEmpty(_argument) ? DefaultArgument : _argument;

        internal RegexAssertion(Assertation assertion)
        {
            _argument = string.Empty;
            _assertion = assertion;
            Contains = new Contains(this);
            Validates = new Validates(this);
        }

        public IMust Must(string input)
        {
            _input = input;
            isMustNot = false;
            return this;
        }

        public IMustNot MustNot(string input)
        {
            _input = input;
            isMustNot = true;
            return this;
        }

        public IRegexAssert Match(string pattern)
        {
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} doesn't match with the given regex {pattern}.";
            var error = Error.Validation(errorCode, errorMessage);
            return Match(pattern, error);
        }

        public IRegexAssert MinLength(int min)
        {
            var pattern = string.Concat(@".{", min, @",}");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} must be least {min} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Match(pattern, error);
        }

        public IRegexAssert MaxLength(int max)
        {
            var pattern = string.Concat(@"^.{1,", max, @"}$");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} cannot be more than {max} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Match(pattern, error);
        }

        public IRegexAssert Length(int min, int max)
        {
            var pattern = string.Concat(@"^.{", min, @",", max, @"}$");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} must be between {min} and {max} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Match(pattern, error);
        }

        public IRegexAssertion WithDefaultError(string name)
        {
            if(!_assertion.Failed)
                return this;

            var error =_assertion.Errors[_assertion.Errors.Count - 1];
            var errorCode = error.Code;
            var errorMessage = error.Message;

            _argument = string.IsNullOrEmpty(name) ? DefaultArgument : name;
            errorCode = errorCode.Replace(PrefixError, Argument);
            errorMessage = errorMessage.Replace(DefaultArgument, Argument);
            error = Error.Validation(errorCode, errorMessage);
            _assertion.Errors.RemoveAt(_assertion.Errors.Count - 1);
            _assertion.Errors.Add(error);
            _argument = string.Empty;

            if(isMustNot)
                return this as IMustNot;
            else
                return this as IMust;
        }

        public IRegexAssertion WithError(Error error)
        {
            if(_assertion.Failed)
            {
                _assertion.Errors.RemoveAt(_assertion.Errors.Count - 1);
                _assertion.Errors.Add(error);
            }

            if(isMustNot)
                return this as IMustNot;
            else
                return this as IMust;
        }

        internal IRegexAssert Match(string pattern, Error error)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            _assertion.IsSatisfied = isMustNot ? !isMatch : isMatch;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(error);

            return this;
        }
    }
}