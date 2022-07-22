namespace AssertiveResults.Assertions
{
    public interface IRegex
    {
        Assertion WithError(string errorMessage);
    }
}