using System;

namespace AssertiveResults.Contracts
{
    public interface IMatch
    {
        void Match(Action<IMetadata> onSuccess,
                   Action<(IProblem problem, IMetadata metadata)> onFailure);
    }

    public interface IMatch<T>
    {
        void Match(Action<(T value, IMetadata metadata)> onSuccess,
                   Action<(IProblem problem, IMetadata metadata)> onFailure);

        U Match<U>(Func<(T value, IMetadata metadata), U> onSuccess,
                   Func<(IProblem problem, IMetadata metadata), U> onFailure);
    }
}