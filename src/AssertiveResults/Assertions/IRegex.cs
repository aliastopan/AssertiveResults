using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IRegex
    {
        IRegex Pattern(string pattern);
        IRegex WithError(Error error);
    }
}