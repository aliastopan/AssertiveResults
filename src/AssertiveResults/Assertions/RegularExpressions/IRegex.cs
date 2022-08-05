namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IRegex
    {
        IRegexAssertion Validates(string input);
    }
}