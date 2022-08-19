using System;
using Behavior = AssertiveResults.ResolveBehavior;

namespace AssertiveResults.Contracts
{
    public interface IResolve
    {
        IResult Resolve();
        IResult Resolve(Action<IExamine> examine);
        IResult Resolve(Behavior behavior, Action<IExamine> examine);
    }

    public interface IResolve<T>
    {
        IResult<T> Resolve(Func<IExamine<T>, T> examine);
        IResult<T> Resolve(Behavior behavior, Func<IExamine<T>, T> examine);
    }
}