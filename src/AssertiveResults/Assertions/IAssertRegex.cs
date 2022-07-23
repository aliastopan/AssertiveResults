namespace AssertiveResults.Assertions
{
    public interface IAssertRegex
    {
        IRegexMatch Match(string input);
        IRegexInvalid Invalid(string input);
    }
}