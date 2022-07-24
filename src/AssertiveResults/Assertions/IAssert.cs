namespace AssertiveResults.Assertions
{
    public interface IAssert
    {
        IAssertMust Satisfy(bool condition);
        IAssertMust NotSatisfy(bool condition);
    }
}