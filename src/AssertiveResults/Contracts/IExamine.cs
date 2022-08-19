namespace AssertiveResults.Contracts
{
    public interface IExamine : IProblem, IMetadata
    {
        bool HasError { get; }

        int PurgeErrors();
    }

    public interface IExamine<T> : IExamine
    {
        T Value { get;}
    }
}