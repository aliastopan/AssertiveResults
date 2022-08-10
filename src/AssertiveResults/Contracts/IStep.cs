using System;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface IStep
    {
        IStep Assert(Action<IContext> context);
        IStep<T> Override<T>();
        IResult Resolve();
    }

    public interface IStep<T>
    {
        IStep<T> Assert(Action<IContext> context);
        IStep<U> Override<U>();
        IStep<U> Override<U>(out T value);
        IStep Override();
        IResult<T> Resolve(Func<IResolve, T> result);
        IResult<T> Resolve(ResolveBehavior resolveBehavior, Func<IResolve, T> result);
    }
}