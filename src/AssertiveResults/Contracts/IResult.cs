using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<IContext> context);
        IBreak Break();
        IAssertiveResult Resolve();
        IAssertiveResult<T> Resolve<T>(Func<IResolve, T> result);
        IAssertiveResult<T> Resolve<T>(ResolveMethod resolveMethod, Func<IResolve, T> result);
    }
}