namespace AssertiveResults.Assertions
{
    public class Context
    {
        public bool HasNoError { get; }

        public Context(bool hasNoError)
        {
            HasNoError = hasNoError;
        }
    }
}