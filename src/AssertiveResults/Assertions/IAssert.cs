namespace AssertiveResults.Assertions
{
    public interface IAssert
    {
        Must Must { get; }
        Regex Regex { get; }
    }
}