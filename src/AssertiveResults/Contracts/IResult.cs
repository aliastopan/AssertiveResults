using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<IContext> context);
        IBreak Break();
        IAssertiveResult Resolve();
    }

    public interface IResult<T> : IResult
    {
        new IResult<T> Assert(Action<IContext> context);
        new IBreak<T> Break();
        new IAssertiveResult<T> Resolve();
        IAssertiveResult<T> Resolve(Func<IResolve, T> result);
        IAssertiveResult<T> Resolve(ResolveBehavior resolveBehavior, Func<IResolve, T> result);
    }
}