using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IAssert : IAssertion
    {
        IAssertion WithError(Error error);
        IAssertion WithErrorDefault(string inputName = "Input", string errorCode = "");
    }
}