namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IRegex
    {
        IMatch Validate(string input);
    }
}