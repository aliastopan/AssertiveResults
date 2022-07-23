using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IAssertion
    {
        Assertion WithError(Error error);
    }
}