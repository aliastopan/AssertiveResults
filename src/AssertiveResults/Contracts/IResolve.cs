using System;
using Behavior = AssertiveResults.ResolveBehavior;

namespace AssertiveResults.Contracts
{
    public interface IResolve
    {
        IResult Resolve();
        IResult Resolve(Action<IInspect> check);
        IResult Resolve(Behavior behavior, Action<IInspect> check);
    }

    public interface IResolve<T>
    {
        IResult<T> Resolve(Func<IInspect<T>, T> check);
        IResult<T> Resolve(Behavior behavior, Func<IInspect<T>, T> check);
    }
}