namespace AssertiveResults.Assertions
{
    public interface IAssert
    {
        IMust Must { get; }
        IRegex Regex { get; }
    }
}