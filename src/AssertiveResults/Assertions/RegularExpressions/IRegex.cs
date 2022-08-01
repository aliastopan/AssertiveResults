namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IRegex
    {
        IRegexAssertion Match(string input);
    }
}