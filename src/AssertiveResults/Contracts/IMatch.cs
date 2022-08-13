using System;

namespace AssertiveResults.Contracts
{
    public interface IMatch
    {
        void Match(Action<IMetadata> onSuccess,
                   Action<(IMetadata metadata, IProblem problem)> onFailure);
    }

    public interface IMatch<T>
    {
        void Match(Action<(T value, IMetadata metadata)> onSuccess,
                   Action<(IMetadata metadata, IProblem problem)> onFailure);

        U Match<U>(Func<(T value, IMetadata metadata), U> onSuccess,
                   Func<(IMetadata metadata, IProblem problem), U> onFailure);
    }
}