using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IResult : IMatch
    {
        IMatch WithError(IError error);
    }
}