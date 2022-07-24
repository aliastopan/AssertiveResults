using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<IAssertion> assert);
        IBreak Break();
        IAssertiveResult Return();
        IAssertiveResult<T> Return<T>(T value);
    }
}