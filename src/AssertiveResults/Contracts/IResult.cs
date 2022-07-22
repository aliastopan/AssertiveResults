using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<Assertion> assert);
        IBreakPoint Break();
        IAssertiveResult Return();
    }
}