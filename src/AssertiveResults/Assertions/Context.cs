namespace AssertiveResults.Assertions
{
    public class Context
    {
        public bool HasNoError { get; private set; }

        public Context(bool hasNoError)
        {
            HasNoError = hasNoError;
        }
    }
}