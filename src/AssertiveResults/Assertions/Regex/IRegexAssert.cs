using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssert : IRegexAssertion
    {
        IRegexAssertion WithErrorDefault(string argumentName = "Input", string errorCode = "");
        IRegexAssertion WithError(Error error);
    }
}