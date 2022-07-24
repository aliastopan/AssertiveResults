using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IAssertMust : IAssert
    {
        IAssert WithError(Error error);
    }
}