using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults.Contracts
{
    public interface IProblem
    {
        IReadOnlyCollection<IError> Errors { get; }
        IError FirstError { get; }
        IError LastError { get; }
    }
}