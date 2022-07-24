namespace AssertiveResults.Assertions
{
    public interface IAssertion
    {
        IAssert Must { get; }
        IAssertRegex Regex { get; }
    }
}