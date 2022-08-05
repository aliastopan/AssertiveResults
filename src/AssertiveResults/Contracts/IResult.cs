using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<IContext> context);
        IAssertiveResult Resolve();
    }

    public interface IResult<T>
    {
        IResult<T> Assert(Action<IContext> context);
        IAssertiveResult<T> Resolve(Func<IResolve, T> result);
        IAssertiveResult<T> Resolve(ResolveBehavior resolveBehavior, Func<IResolve, T> result);
    }
}