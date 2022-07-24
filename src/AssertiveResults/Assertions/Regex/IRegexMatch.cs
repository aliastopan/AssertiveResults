using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IRegexMatch : IRegex
    {
        IRegex WithError(Error error);
    }
}