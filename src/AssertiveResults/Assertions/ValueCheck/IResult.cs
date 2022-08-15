using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.ValueCheck
{
    public interface IResult
    {
        IValueCheck WithError(IError error);
        IValueCheck WithError(IError error, params object[] args);
    }
}