using RegularExpression = System.Text.RegularExpressions.Regex;
using AssertiveResults.Assertions.Regex.Verbs;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssertion
    {
        IRegexAssert Match(string pattern);
        IRegexAssert Match(RegularExpression regex);
        IContains Contains { get; }
    }

    public interface IMust : IRegexAssertion
    {
        IRegexAssert MinLength(int min);
        IRegexAssert MaxLength(int max);
        IRegexAssert Length(int min, int max);
    }

    public interface IMustNot : IRegexAssertion
    {

    }
}