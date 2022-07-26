using AssertiveResults.Assertions.Regex.Verbs;

namespace AssertiveResults.Assertions.Regex
{
    public interface IRegexAssertion
    {
        IContains Contains { get; }
        IValidates Validates { get; }

        IRegexAssert Against(string pattern);
        IRegexAssert AgainstInvalid(string pattern);
        IRegexAssert Length(int min, int max);
        IRegexAssert MinLength(int min);
        IRegexAssert MaxLength(int max);
    }
}