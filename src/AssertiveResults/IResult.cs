using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface IResult : IBegin, ISubject, IProblem, IResolve, IMetadata
    {
        bool Success { get; }
        bool Failed { get; }
    }

    public interface IResult<T> : IResult, IBegin<T>, ISubject<T>, IMetadata<T>, IMatch<T>
    {
        T Value { get; }
    }
}