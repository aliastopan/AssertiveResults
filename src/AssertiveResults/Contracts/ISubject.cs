using System;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface ISubject : IOverload, IOverride, IResolve
    {
        ISubject Assert(Action<IContext> context);
    }

    public interface ISubject<T> : IOverload<T>, IOverride<T>, IResolve<T>
    {
        ISubject<T> Assert(Action<IContext> context);
    }
}