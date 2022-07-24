using RegularExpression = System.Text.RegularExpressions.Regex;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssertion
    {
        IRegexAssert Match(string pattern);
        IRegexAssert Match(RegularExpression regex);
        IRegexAssert MinLength(int min);
        IRegexAssert MaxLength(int max);
        IRegexAssert Length(int min, int max);
    }
}