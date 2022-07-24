using RegularExpression = System.Text.RegularExpressions.Regex;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssertion
    {
        IRegexAssert Match(string pattern);
        IRegexAssert Match(RegularExpression regex);
    }
}