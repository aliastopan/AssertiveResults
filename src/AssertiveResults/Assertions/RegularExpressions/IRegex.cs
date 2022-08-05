namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IRegex
    {
        IRegexAssertion Validate(string input);
    }
}