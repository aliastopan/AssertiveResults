using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IResult : IMatch
    {
        IMatch WithError(Error error);
    }
}