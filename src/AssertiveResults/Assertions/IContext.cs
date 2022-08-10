using AssertiveResults.Assertions.Exception;
using AssertiveResults.Assertions.RegularExpressions;

namespace AssertiveResults.Assertions
{
    public interface IContext
    {
        IAssertion Should { get; }
        IRegex RegularExpression { get; }
        IException Exception { get; }
    }
}