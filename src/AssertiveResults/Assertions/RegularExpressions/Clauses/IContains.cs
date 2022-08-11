namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    public interface IContains
    {
        IResult LowerCase();
        IResult UpperCase();
        IResult Alphabet();
        IResult Alphameric();
        IResult Number();
        IResult Symbol();
    }
}