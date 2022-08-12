namespace AssertiveResults.Contracts
{
    public interface IInspect : IProblem
    {
        bool HasError { get; }

        int PurgeErrors();
    }
}