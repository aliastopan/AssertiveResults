using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Assertions.Regex.Verbs;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssertion
    {
        IContains Contains { get; }
        IRegexAssert Match(string pattern);
        IRegexAssert Match(RegularExpression regex);
    }

    public interface IMust : IRegexAssertion
    {
        IValidates Validates { get; }
        IRegexAssert MinLength(int min);
        IRegexAssert MaxLength(int max);
        IRegexAssert Length(int min, int max);
    }

    public interface IMustNot : IRegexAssertion
    {

    }
}