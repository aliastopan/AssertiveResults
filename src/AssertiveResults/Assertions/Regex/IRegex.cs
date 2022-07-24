namespace AssertiveResults.Assertions
{
    public interface IRegex
    {
        IRegexAssertion Matches(string input);
        IRegexAssertion Invalid(string input);
    }
}