using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface IResult :
        IBegin,
        ISubject,
        IProblem,
        IInspect,
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