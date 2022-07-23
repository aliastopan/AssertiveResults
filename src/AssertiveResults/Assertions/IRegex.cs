namespace AssertiveResults.Assertions
{
    public interface IRegex
    {
        IMatch Match(string input);
        IMatch Invalid(string input);
    }
}