using System;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using Behavior = AssertiveResults.ResolveBehavior;

namespace AssertiveResults
{
    public interface ISubject
    {
        ISubject Assert(Action<IContext> context);
        ISubject Overload();
        ISubject<T> Override<T>();
        IResult Resolve();
        IResult Resolve(Action<IResolve> context);
        IResult Resolve(Behavior behavior, Action<IResolve> context);
    }

    public interface ISubject<T> : ISubject
    {
        new ISubject<T> Assert(Action<IContext> context);
        new ISubject<T> Overload();
        ISubject<U> Override<U>(out T value);
        ISubject Override(out T value);
        IResult<T> Resolve(Func<IResolve, T> context);
        IResult<T> Resolve(Behavior behavior, Func<IResolve, T> context);
    }
}