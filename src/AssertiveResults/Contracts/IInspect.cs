namespace AssertiveResults.Contracts
{
    public interface IInspect : IProblem, IMetadata
    {
        bool HasError { get; }

        int PurgeErrors();
    }

    public interface IInspect<T> : IInspect
    {
        T Value { get;}
    }
}