using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssert : IRegexAssertion
    {
        IRegexAssertion WithDefaultError(string argumentName);
        IRegexAssertion WithError(Error error);
    }
}