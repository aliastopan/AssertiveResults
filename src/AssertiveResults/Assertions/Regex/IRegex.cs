namespace AssertiveResults.Assertions.Regex
{
    public interface IRegex
    {
        IRegexAssertion Matches(string input);
        IRegexAssertion Invalid(string input);
    }
}