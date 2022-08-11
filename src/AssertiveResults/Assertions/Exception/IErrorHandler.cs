using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Exception
{
    public interface IErrorHandler
    {
        void Catch(Error error);
    }
}