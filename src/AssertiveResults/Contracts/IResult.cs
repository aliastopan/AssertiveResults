using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface IResult :
        IBegin,
        ISubject,
        IProblem,
        IMatch,
        IMetadata
    {
        bool IsSuccess { get; }
        bool HasFailed { get; }
    }

    public interface IResult<T> : IResult,
        IBegin<T>,
        ISubject<T>,
        IMatch<T>,
        IMetadata<T>
    {
        T Value { get; }
    }
}