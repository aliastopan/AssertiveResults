using AssertiveResults.Errors;
using System.Collections.Generic;

namespace AssertiveResults
{
    public interface IAssertiveResult
    {
        bool Success { get; }
        bool Failed { get; }
        IReadOnlyCollection<Error> Errors { get; }
        Error FirstError { get; }
        Error LastError { get; }
    }

    public interface IAssertiveResult<T> : IAssertiveResult
    {
        T Value { get; }
    }
}