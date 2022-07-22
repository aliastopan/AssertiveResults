using AssertiveResults.Errors;
using System.Collections.Generic;

namespace AssertiveResults
{
    public interface IAssertiveResult
    {
        bool Success { get; }
        bool Failed { get; }
        IReadOnlyCollection<Error> Errors { get; }
    }

    public interface IAssertiveResult<T> : IAssertiveResult
    {
        T Value { get; }
    }
}