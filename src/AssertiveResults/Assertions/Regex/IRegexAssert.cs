using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssert : IRegexAssertion
    {
        IRegexAssertion WithDefaultError(string argumentName);
        IRegexAssertion WithError(Error error);
    }

    public interface IRegexAssertValidates : IRegexAssertion
    {
        IRegexAssertion WithError(Error error);
    }
}