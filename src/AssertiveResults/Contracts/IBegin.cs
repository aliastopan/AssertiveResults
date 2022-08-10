using System;
using AssertiveResults.Assertions;

namespace AssertiveResults.Contracts
{
    public interface IBegin
    {
        IStep Assert(Action<IContext> context);
    }

    public interface IBegin<T> : IBegin
    {
        new IStep<T> Assert(Action<IContext> context);
    }
}