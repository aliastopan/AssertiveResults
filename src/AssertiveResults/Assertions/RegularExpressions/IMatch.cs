using AssertiveResults.Assertions.RegularExpressions.Clauses;

namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IMatch
    {
        IContains Contains { get; }
        IFormat Format { get; }

        IResult Matches(string pattern);
        IResult MatchesIllegal(string pattern);
        IResult Length(int min, int max);
        IResult MinLength(int min);
        IResult MaxLength(int max);
    }
}