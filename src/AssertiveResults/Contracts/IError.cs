using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults.Contracts
{
    public interface IError
    {
        IReadOnlyCollection<Error> Errors { get; }
        Error FirstError { get; }
        Error LastError { get; }
    }
}