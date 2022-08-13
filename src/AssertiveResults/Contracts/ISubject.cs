using System;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;

namespace AssertiveResults
{
    public interface ISubject :
        IResolve,
        IOverload,
        IOverride
    {
        ISubject Assert(Action<IContext> context);
    }

    public interface ISubject<T> :
        IResolve<T>,
        IOverload<T>,
        IOverride<T>
    {
        ISubject<T> Assert(Action<IContext> context);
    }
}