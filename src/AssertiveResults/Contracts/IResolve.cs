using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults.Contracts
{
    public interface IResolve
    {
        bool HasError { get; }
        IReadOnlyCollection<Error> Errors { get; }

        int PurgeErrors();
    }
}