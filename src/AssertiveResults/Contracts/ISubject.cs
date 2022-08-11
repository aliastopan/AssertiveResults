using System;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface ISubject
    {
        ISubject Assert(Action<IContext> context);
        ISubject<T> Override<T>();
        IResult Resolve();
    }

    public interface ISubject<T>
    {
        ISubject<T> Assert(Action<IContext> context);
        ISubject<U> Override<U>();
        ISubject<U> Override<U>(out T value);
        ISubject Override();
        IResult<T> Resolve(Func<IResolve, T> result);
        IResult<T> Resolve(ResolveBehavior resolveBehavior, Func<IResolve, T> result);
    }
}