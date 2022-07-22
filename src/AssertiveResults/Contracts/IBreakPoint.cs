using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IBreakPoint
    {
        IResult Assert(Action<Assertion> assert);
    }
}