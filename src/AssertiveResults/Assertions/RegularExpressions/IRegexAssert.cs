using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IRegexAssert : IRegexAssertion
    {
        IRegexAssertion WithError(Error error);
    }
}