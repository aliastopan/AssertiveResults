using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IAssert : IAssertion
    {
        IAssertion Otherwise(Error error);
    }
}