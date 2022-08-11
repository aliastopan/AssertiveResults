using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults.Contracts
{
    public interface IProblem
    {
        IReadOnlyCollection<Error> Errors { get; }
        Error FirstError { get; }
        Error LastError { get; }
    }
}