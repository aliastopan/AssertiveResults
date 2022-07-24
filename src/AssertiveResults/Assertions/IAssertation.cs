using AssertiveResults.Assertions.Regex;

namespace AssertiveResults.Assertions
{
    public interface IAssertation
    {
        IAssertion Must { get; }
        IRegex Regex { get; }
    }
}