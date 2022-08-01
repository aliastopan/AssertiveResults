namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    public interface IContains
    {
        IRegexAssert LowerCase();
        IRegexAssert UpperCase();
        IRegexAssert Alphabet();
        IRegexAssert Alphameric();
        IRegexAssert Number();
        IRegexAssert Symbol();
    }
}