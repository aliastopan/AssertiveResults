namespace AssertiveResults.Assertions.Regex
{
    public interface IRegex
    {
        IRegexAssertion Must(string input);
        IRegexAssertion MustNot(string input);
    }
}