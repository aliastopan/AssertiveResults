using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IAssertive
    {
        IResult Assert(Action<IContext> context);
    }
}