namespace AssertiveResults.Assertions
{
    public interface IAssertation
    {
        IAssertion Must { get; }
        IAssertRegex Regex { get; }
    }
}