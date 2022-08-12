using System;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using Behavior = AssertiveResults.ResolveBehavior;

namespace AssertiveResults
{
    public interface ISubject : IOverload, IOverride
    {
        ISubject Assert(Action<IContext> context);
        IResult Resolve();
        IResult Resolve(Action<IInspect> context);
        IResult Resolve(Behavior behavior, Action<IInspect> context);
    }

    public interface ISubject<T> : IOverload<T>, IOverride<T>
    {
        ISubject<T> Assert(Action<IContext> context);
        IResult<T> Resolve(Func<IInspect, T> context);
        IResult<T> Resolve(Behavior behavior, Func<IInspect, T> context);
    }
}