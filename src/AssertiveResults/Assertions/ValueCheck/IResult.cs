using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.ValueCheck
{
    public interface IResult
    {
        IValueCheck WithError(Error error);
    }
}