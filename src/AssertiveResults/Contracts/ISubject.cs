using System;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using Behavior = AssertiveResults.ResolveBehavior;

namespace AssertiveResults
{
    public interface ISubject : IOverload
    {
        ISubject Assert(Action<IContext> context);
        ISubject<T> Override<T>();
        IResult Resolve();
        IResult Resolve(Action<IInspect> context);
        IResult Resolve(Behavior behavior, Action<IInspect> context);
    }

    public interface ISubject<T> : IOverload<T>
    {
        ISubject<T> Assert(Action<IContext> context);
        ISubject<U> Override<U>(out T value);
        ISubject Override(out T value);
        IResult<T> Resolve(Func<IInspect, T> context);
        IResult<T> Resolve(Behavior behavior, Func<IInspect, T> context);
    }
}