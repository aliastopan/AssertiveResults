namespace AssertiveResults.Assertions.Regex
{
    public interface IRegex
    {
        IRegexAssertion Match(string input);
    }
}