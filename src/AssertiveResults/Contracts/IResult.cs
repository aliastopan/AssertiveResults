using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<IAssertation> context);
        IBreak Break();
        IAssertiveResult Resolve();
        IAssertiveResult<T> Resolve<T>(Func<IResolve, T> result, ResolveMethod resolveMethod = ResolveMethod.Default);
    }
}