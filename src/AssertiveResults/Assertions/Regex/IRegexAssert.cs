using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssert : IRegexAssertion
    {
        IRegexAssertion WithError(Error error);
        IRegexAssertion WithErrorDefault(string inputName = "Input", string errorCode = "");
    }
}