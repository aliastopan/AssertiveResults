using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.ErrorHandling
{
    public interface IErrorHandler
    {
        void Catch(IError error);
    }
}