using System.Collections.Generic;
using AssertiveResults.Errors;

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