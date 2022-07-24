namespace AssertiveResults.Assertions.Regex
{
    public interface IRegex
    {
        IMust Must(string input);
        IMustNot MustNot(string input);
    }
}