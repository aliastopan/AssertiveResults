namespace AssertiveResults.Errors
{
    public interface IError
    {
        ErrorType Type { get; }
        int NumericType { get; }
        string Code { get; }
        string Description { get; }
    }
}