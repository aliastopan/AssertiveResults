namespace AssertiveResults.Assertions
{
    public interface IMust
    {
        Assertion WithError(string errorMessage);
    }
}