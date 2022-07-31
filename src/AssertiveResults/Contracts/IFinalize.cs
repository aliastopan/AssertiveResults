using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults.Contracts
{
    public interface IFinalize
    {
        bool HasError { get; }
        IReadOnlyCollection<Error> Errors { get; }
    }
}