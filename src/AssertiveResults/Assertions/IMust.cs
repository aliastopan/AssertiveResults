using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IMust
    {
        Assertion WithError(string errorMessage);
        Assertion WithError(Error error);
    }
}