using System;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface ISubject
    {
        ISubject Assert(Action<IContext> context);
        ISubject Overload();
        ISubject<T> Override<T>();
        IResult Resolve();
        IResult Resolve(Action<IResolve> context);
        IResult Resolve(ResolveBehavior resolveBehavior, Action<IResolve> context);
    }

    public interface ISubject<T> : ISubject
    {
        new ISubject<T> Assert(Action<IContext> context);
        new ISubject<T> Overload();
        ISubject<U> Override<U>(out T value);
        ISubject Override(out T value);
        IResult<T> Resolve(Func<IResolve, T> context);
        IResult<T> Resolve(ResolveBehavior resolveBehavior, Func<IResolve, T> context);
    }
}