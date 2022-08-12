namespace AssertiveResults.Contracts
{
    public interface IOverride
    {
        ISubject<T> Override<T>();
    }

    public interface IOverride<T>
    {
        ISubject<U> Override<U>(out T value);
        ISubject Override(out T value);
    }
}