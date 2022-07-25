using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssert : IRegexAssertion
    {
        IRegexAssertion WithArgName(string argName);
        IRegexAssertion WithError(Error error);
    }
}