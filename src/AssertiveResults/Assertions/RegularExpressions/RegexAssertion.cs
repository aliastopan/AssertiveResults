using System.Text.RegularExpressions;
using AssertiveResults.Assertions.RegularExpressions.Clauses;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions
{
    public class RegexAssertion : IRegexAssertion, IRegex, IRegexAssert
    {
        internal Assertation assertation;
        private string _input;

        internal RegexAssertion(Assertation assertation)
        {
            this.assertation = assertation;
            Contains = new Contains(this);
            Validates = new Validates(this);
        }

        public IContains Contains { get; internal set; }
        public IValidates Validates { get; internal set; }

        public IRegexAssertion Match(string input)
        {
            _input = input;
            return this;
        }

        public IRegexAssert Against(string pattern)
        {
            var errorCode = "Regex.Validation";
            var errorDescription = $"{assertation.InputName} doesn't match with the given {pattern} expression.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert AgainstIllegal(string pattern)
        {
            var errorCode = "Regex.Validation";
            var errorDescription = $"{assertation.InputName} match with the given illegal {pattern} expression.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error, illegal: true);
        }

        public IRegexAssert Length(int min, int max)
        {
            var pattern = Expression.Length(min, max);
            var errorCode = "Length.Validation";
            var errorDescription = $"{assertation.InputName} must be between {min} and {max} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert MinLength(int min)
        {
            var pattern = Expression.MinLength(min);
            var errorCode = "MinLength.Validation";
            var errorDescription = $"{assertation.InputName} must be least {min} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssert MaxLength(int max)
        {
            var pattern = Expression.MaxLength(max);
            var errorCode = "MaxLength.Validation";
            var errorDescription = $"{assertation.InputName} cannot be more than {max} characters.";
            var error = Error.Validation(errorCode, errorDescription);
            return Regex(pattern, error);
        }

        public IRegexAssertion Otherwise(Error error)
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
            var regex = new Regex(pattern);
            var isMatch = regex.IsMatch(_input);
            assertation.IsSatisfied = illegal ? !isMatch : isMatch;
            if(!assertation.IsSatisfied)
                assertation.Errors.Add(error);

            return this;
        }
    }
}