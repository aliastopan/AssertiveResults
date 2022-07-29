using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IResult
    {
        IResult Assert(Action<IAssertation> assert);
        IBreak Break();
        IAssertiveResult Return();
        IAssertiveResult<T> Return<T>(T value, bool overwrite = false);
    }
}