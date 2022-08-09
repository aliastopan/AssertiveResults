using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public interface IAssertiveResult
    {
        IReadOnlyCollection<Error> Errors { get; }
        Error FirstError { get; }
        Error LastError { get; }

        IReadOnlyDictionary<string, object> Metadata { get; }
        bool HasMetadata { get; }

        bool Success { get; }
        bool Failed { get; }

        IAssertiveResult WithMetadata(string metadataName, object metadataValue);
        object GetMetadata(string metadataName);
        IResult Overload();
        IResult<T> Override<T>();
    }

    public interface IAssertiveResult<T> : IAssertiveResult
    {
        T Value { get; }

        new IAssertiveResult<T> WithMetadata(string metadataName, object metadataValue);
        new IResult<T> Overload();
        new IResult<U> Override<U>();
        IResult Override();
    }
}