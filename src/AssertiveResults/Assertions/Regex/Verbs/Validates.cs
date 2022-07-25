namespace AssertiveResults.Assertions.Regex.Verbs
{
    public class Validates : IValidates
    {
        private RegexAssertion _regexAssertion;

        internal Validates(RegexAssertion regexAssertion)
        {
            _regexAssertion = regexAssertion;
        }

        public IRegexAssertValidates Username()
        {
            return _regexAssertion;
        }

        public IRegexAssertValidates PasswordStrength()
        {
            _regexAssertion.MinLength(8).WithArgName("Password");
            _regexAssertion.Contains.LowerCase().WithArgName("Password");
            _regexAssertion.Contains.UpperCase().WithArgName("Password");
            _regexAssertion.Contains.Number().WithArgName("Password");
            return _regexAssertion;
        }

        public IRegexAssertValidates Email()
        {
            return _regexAssertion;
        }
    }
}