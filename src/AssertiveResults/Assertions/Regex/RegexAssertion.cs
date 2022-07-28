using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.Regex.Clauses;

namespace AssertiveResults.Assertions.Regex
{
    public class RegexAssertion : IRegexAssertion, IRegex, IRegexAssert
    {
        internal Assertation assertation;
        private string _input;

        public IContains Contains { get; internal set; }
        public IValidates Validates { get; internal set; }

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
            var errorCode = $"{assertation.InputName}.Expression.Validation";
            var errorDescription = $"{assertation.InputName} doesn't match with the given {pattern} expression.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert AgainstIllegal(string pattern)
        {
            var errorCode = $"{assertation.InputName}.Expression.Validation";
            var errorDescription = $"{assertation.InputName} match with the given illegal {pattern} expression.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error, illegal: true);
        }

        public IRegexAssert Length(int min, int max)
        {
            var pattern = Expression.Length(min, max);
            var errorCode = $"{assertation.InputName}.Length.Validation";
            var errorDescription = $"{assertation.InputName} must be between {min} and {max} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert MinLength(int min)
        {
            var pattern = Expression.MinLength(min);
            var errorCode = $"{assertation.InputName}.MaxLength.Validation";
            var errorDescription = $"{assertation.InputName} must be least {min} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert MaxLength(int max)
        {
            var pattern = Expression.MaxLength(max);
            var errorCode = $"{assertation.InputName}.MaxLength.Validation";
            var errorDescription = $"{assertation.InputName} cannot be more than {max} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssertion WithErrorDefault(string inputName = "Input", string errorCode = "")
        {
            ErrorHandler.WithErrorDefault(assertation, ErrorType.Validation, inputName, errorCode);
            return this;
        }

        public IRegexAssertion WithError(Error error)
        {
            ErrorHandler.WithError(assertation, error);
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