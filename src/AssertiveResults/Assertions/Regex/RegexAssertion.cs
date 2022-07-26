using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.Regex.Verbs;

namespace AssertiveResults.Assertions.Regex
{
    public class RegexAssertion : IRegexAssertion, IRegex, IRegexAssert
    {
        internal Assertation assertation;
        private const string PREFIX_ERROR = "Regex";
        private const string INPUT_ARGUMENT = "Input";
        private string _input;

        public IContains Contains { get; internal set; }
        public IValidates Validates { get; internal set; }
        internal string PrefixError => PREFIX_ERROR;
        internal string InputArgument => INPUT_ARGUMENT;

        internal RegexAssertion(Assertation assertation)
        {
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
            var errorMessage = $"{InputArgument} doesn't match with the given {pattern} expression.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error);
        }

        public IRegexAssert AgainstIllegal(string pattern)
        {
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{InputArgument} match with the given illegal {pattern} expression.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error, illegal: true);
        }

        public IRegexAssert Length(int min, int max)
        {
            var pattern = string.Concat(@"^.{", min, @",", max, @"}$");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{InputArgument} must be between {min} and {max} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error);
        }

        public IRegexAssert MinLength(int min)
        {
            var pattern = string.Concat(@".{", min, @",}");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{InputArgument} must be least {min} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error);
        }

        public IRegexAssert MaxLength(int max)
        {
            var pattern = string.Concat(@"^.{1,", max, @"}$");
            var errorCode = $"{PrefixError}.Validation";
            var errorMessage = $"{InputArgument} cannot be more than {max} characters.";
            var error = Error.Validation(errorCode, errorMessage);
            return Regex(pattern, error);
        }

        public IRegexAssertion WithErrorDefault(string argumentName = "Input", string errorCode = "")
        {
            if(!assertation.Failed)
                return this;

            var error = assertation.Errors[assertation.Errors.Count - 1];
            var code = error.Code;
            var message = error.Message;

            if(string.IsNullOrEmpty(argumentName))
                argumentName = InputArgument;

            if(errorCode == "" && argumentName != InputArgument)
            {
                code = code.Replace(PrefixError, argumentName);
                message = message.Replace(InputArgument, argumentName);
            }

            if(errorCode != "")
            {
                code = errorCode;
                message = message.Replace(InputArgument, argumentName);
            }

            error = Error.Validation(code, message);

            assertation.Errors.RemoveAt(assertation.Errors.Count - 1);
            assertation.Errors.Add(error);

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

        internal IRegexAssert Regex(string pattern, Error error, bool illegal = false)
        {
            var regex = new RegularExpression(pattern);
            var isMatch = regex.IsMatch(_input);
            assertation.IsSatisfied = illegal ? !isMatch : isMatch;
            if(!assertation.IsSatisfied)
                assertation.Errors.Add(error);

            return this;
        }
    }
}