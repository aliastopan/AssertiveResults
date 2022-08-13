namespace AssertiveResults.Contracts
{
    public interface IInspect : IProblem, IMetadata
    {
        bool HasError { get; }

        int PurgeErrors();
    }
}