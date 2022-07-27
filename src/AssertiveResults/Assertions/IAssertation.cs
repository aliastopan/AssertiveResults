using AssertiveResults.Assertions.Regex;

namespace AssertiveResults.Assertions
{
    public interface IAssertation
    {
        IAssertion Should { get; }
        IRegex Regex { get; }
    }
}