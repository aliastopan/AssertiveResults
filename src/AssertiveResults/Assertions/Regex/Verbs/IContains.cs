namespace AssertiveResults.Assertions.Regex.Verbs
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