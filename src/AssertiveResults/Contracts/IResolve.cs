using System;
using Behavior = AssertiveResults.ResolveBehavior;

namespace AssertiveResults.Contracts
{
    public interface IResolve
    {
        IResult Resolve();
        IResult Resolve(Action<IInspect> context);
        IResult Resolve(Behavior behavior, Action<IInspect> context);
    }

    public interface IResolve<T>
    {
        IResult<T> Resolve(Func<IInspect, T> context);
        IResult<T> Resolve(Behavior behavior, Func<IInspect, T> context);
    }
}