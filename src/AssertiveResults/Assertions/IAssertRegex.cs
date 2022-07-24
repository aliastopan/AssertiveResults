namespace AssertiveResults.Assertions
{
    public interface IAssertRegex
    {
        IRegex Matches(string input);
        IRegex Invalid(string input);
    }
}