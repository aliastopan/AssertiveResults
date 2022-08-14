namespace AssertiveResults.Errors
{
    public interface IError
    {
        ErrorType Type { get; }
        int NumericType { get; }
        string Title { get; }
        string Detail { get; }
    }
}