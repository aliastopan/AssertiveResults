using AssertiveResults.Assertions.Exception;
using AssertiveResults.Assertions.RegularExpressions;
using AssertiveResults.Assertions.ValueCheck;

namespace AssertiveResults.Assertions
{
    public interface IContext
    {
        IValueCheck Should { get; }
        IRegex RegularExpression { get; }
        IException Exception { get; }
    }
}