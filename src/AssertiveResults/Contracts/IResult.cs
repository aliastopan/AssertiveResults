using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<IAssertation> context);
        IBreak Break();
        IAssertiveResult Finalize();
        IAssertiveResult<T> Finalize<T>(Func<IFinalize, T> result, AssertMethod procedure = AssertMethod.Loose);
    }
}