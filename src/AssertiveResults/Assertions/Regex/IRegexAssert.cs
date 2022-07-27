using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssert : IRegexAssertion
    {
        IRegexAssertion WithErrorDefault(string inputName = "Input", string errorCode = "");
        IRegexAssertion WithError(Error error);
    }
}