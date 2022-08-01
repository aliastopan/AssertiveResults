using AssertiveResults.Assertions.RegularExpressions;

namespace AssertiveResults.Assertions
{
    public interface IAssertation
    {
        IAssertion Should { get; }
        IRegex RegularExpression { get; }
    }
}