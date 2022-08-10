using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Exception
{
    public interface IException
    {
        IException Catch(Error error);
    }
}