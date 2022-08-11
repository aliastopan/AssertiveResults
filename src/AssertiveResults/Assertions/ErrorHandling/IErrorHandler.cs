using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.ErrorHandling
{
    public interface IErrorHandler
    {
        void Catch(Error error);
    }
}