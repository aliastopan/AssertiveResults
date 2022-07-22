using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IRegex
    {
        Assertion WithError(string errorMessage);
        Assertion WithError(Error error);
    }
}