using System;

namespace AssertiveResults.Contracts
{
    public interface IMatch<T>
    {
        void Match(Action<T> onValue, Action<IProblem> onError);
        U Match<U>(Func<T, U> onValue, Func<IProblem, U> onError);
    }
}