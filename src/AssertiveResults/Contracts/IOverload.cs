namespace AssertiveResults.Contracts
{
    public interface IOverload
    {
        ISubject Overload();
    }

    public interface IOverload<T> : IOverload
    {
        new ISubject<T> Overload();
    }
}