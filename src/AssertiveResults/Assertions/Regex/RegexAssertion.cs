using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.Regex.Verbs;

namespace AssertiveResults.Assertions.Regex
{
    public class RegexAssertion : IRegexAssertion, IRegex, IRegexAssert
    {
        internal Assertation assertation;
        private string _argument;
        private string _input;

        public IContains Contains { get; internal set; }
        public IValidates Validates { get; internal set; }
        internal string PrefixError => "Regex";
        internal string DefaultArgument = "Input";
        internal string Argument => string.IsNullOrEmpty(_argument) ? DefaultArgument : _argument;

        internal RegexAssertion(Assertation assertation)
        {
            _argument = string.Empty;
            this.assertation = assertation;
            Contains = new Contains(this);
            Validates = new Validates(this);
        }

        public IRegexAssertion Match(string input)
        {
            _input = input;
            return this;
        }

        public IRegexAssert Against(string pattern)
        {
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} doesn't match with the given {pattern} expression.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error);
        }

        public IRegexAssert AgainstInvalid(string pattern)
        {
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} match with the given illegal {pattern} expression.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error, invalid: true);
        }

        public IRegexAssert Length(int min, int max)
        {
            var pattern = string.Concat(@"^.{", min, @",", max, @"}$");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} must be between {min} and {max} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error);
        }

        public IRegexAssert MinLength(int min)
        {
            var pattern = string.Concat(@".{", min, @",}");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} must be least {min} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error);
        }

        public IRegexAssert MaxLength(int max)
        {
            var pattern = string.Concat(@"^.{1,", max, @"}$");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{DefaultArgument} cannot be more than {max} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error);
        }

        public IRegexAssertion WithDefaultError(string name)
        {
            if(!assertation.Failed)
                return this;

            var error = assertation.Errors[assertation.Errors.Count - 1];
            var errorCode = error.Code;
            var errorMessage = error.Message;

            _argument = string.IsNullOrEmpty(name) ? DefaultArgument : name;
            errorCode = errorCode.Replace(PrefixError, Argument);
            errorMessage = errorMessage.Replace(DefaultArgument, Argument);
            error = Error.Validation(errorCode, errorMessage);
            assertation.Errors.RemoveAt(assertation.Errors.Count - 1);
            assertation.Errors.Add(error);
            _argument = string.Empty;

            return this;
        }

        public IRegexAssertion WithError(Error error)
        {
            if(assertation.Failed)
            {
                assertation.Errors.RemoveAt(assertation.Errors.Count - 1);
                assertation.Errors.Add(error);
            }

            return this;
        }

        internal IRegexAssert Regex(string pattern, Error error, bool invalid = false)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            assertation.IsSatisfied = invalid ? !isMatch : isMatch;
            if(!assertation.IsSatisfied)
                assertation.Errors.Add(error);

            return this;
        }
    }
}