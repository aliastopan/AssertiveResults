using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IBegin
    {
        ISubject Assert(Action<IContext> context);
    }

    public interface IBegin<T> : IBegin
    {
        new ISubject<T> Assert(Action<IContext> context);
    }
}