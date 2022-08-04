using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IAssertive
    {
        IResult Assert(Action<IContext> context);
    }

    public interface IAssertive<T> : IAssertive
    {
        new IResult<T> Assert(Action<IContext> context);
    }
}