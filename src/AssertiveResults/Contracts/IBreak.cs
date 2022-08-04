using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IBreak
    {
        IResult Assert(Action<IContext> context);
    }

    public interface IBreak<T> : IBreak
    {
        new IResult<T> Assert(Action<IContext> context);
    }
}