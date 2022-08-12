using System;
using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface IResult : IMetadata, IProblem
    {
        bool Success { get; }
        bool Failed { get; }

        ISubject Overload();
        ISubject<T> Override<T>();
    }

    public interface IResult<T> : IResult, IMetadata<T>
    {
        T Value { get; }

        new ISubject<T> Overload();
        new ISubject<U> Override<U>();
        ISubject<U> Override<U>(out T value);
        ISubject Override();
        void Match(Action<T> onValue, Action<IProblem> onError);
        U Match<U>(Func<T, U> onValue, Func<IProblem, U> onError);
    }
}