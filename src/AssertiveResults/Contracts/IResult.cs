using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<IAssertation> assert);
        IBreak Break();
        IAssertiveResult Finalize();
        IAssertiveResult<T> Finalize<T>(Func<Context, T> context);
    }
}