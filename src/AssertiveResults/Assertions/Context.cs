namespace AssertiveResults.Assertions
{
    public class Context
    {
        public bool AllCorrect { get; private set; }

        public Context(bool allCorrect)
        {
            AllCorrect = allCorrect;
        }
    }
}