namespace AssertiveResults.Assertions
{
    public interface IRegexMatch : IRegex
    {
        IAssertion MinLength(int min);
        IAssertion MaxLength(int max);
        IAssertion Length(int min, int max);
    }
}