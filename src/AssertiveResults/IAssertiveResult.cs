using AssertiveResults.Contracts;
using AssertiveResults.Errors;
using System.Collections.Generic;

namespace AssertiveResults
{
    public interface IAssertiveResult
    {
        bool Success { get; }
        bool Failed { get; }
        bool HasMetadata { get; }
        IReadOnlyCollection<Error> Errors { get; }
        IReadOnlyDictionary<string, object> Metadata { get; }
        Error FirstError { get; }
        Error LastError { get; }

        IResult Extend();
        IAssertiveResult WithMetadata(string metadataName, object metadataValue);
        object GetMetadata(string metadataName);
    }

    public interface IAssertiveResult<T> : IAssertiveResult
    {
        T Value { get; }

        new IAssertiveResult<T> WithMetadata(string metadataName, object metadataValue);
    }
}