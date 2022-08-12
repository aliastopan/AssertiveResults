namespace AssertiveResults.Contracts
{
    public interface IResolve : IProblem
    {
        bool HasError { get; }

        int PurgeErrors();
    }
}