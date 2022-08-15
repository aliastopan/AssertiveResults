using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.RegularExpressions
{
    public interface IResult : IMatch
    {
        IMatch WithError(IError error);
        IMatch WithError(IError error, params object[] args);
    }
}