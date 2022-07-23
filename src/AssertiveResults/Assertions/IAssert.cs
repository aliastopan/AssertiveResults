namespace AssertiveResults.Assertions
{
    public interface IAssert
    {
        IAssertMust Must { get; }
        IAssertRegex Regex { get; }
    }
}