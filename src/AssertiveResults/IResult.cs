using System;
using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface IResult : IBegin, ISubject, IProblem, IResolve, IMetadata
    {
        bool Success { get; }
        bool Failed { get; }
    }

    public interface IResult<T> : IResult, IBegin<T>, ISubject<T>, IMetadata<T>
    {
        T Value { get; }

        void Match(Action<T> onValue, Action<IProblem> onError);
        U Match<U>(Func<T, U> onValue, Func<IProblem, U> onError);
    }
}