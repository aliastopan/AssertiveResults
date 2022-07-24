using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public interface IRegexAssert : IRegexAssertion
    {
        IRegexAssertion WithError(Error error);
    }
}