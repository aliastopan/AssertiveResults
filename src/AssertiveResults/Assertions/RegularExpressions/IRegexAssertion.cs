using AssertiveResults.Assertions.RegularExpressions.Clauses;

namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IRegexAssertion
    {
        IContains Contains { get; }
        IFormat Format { get; }

        IRegexAssert Matches(string pattern);
        IRegexAssert MatchesIllegal(string pattern);
        IRegexAssert Length(int min, int max);
        IRegexAssert MinLength(int min);
        IRegexAssert MaxLength(int max);
    }
}