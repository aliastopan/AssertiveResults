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

        IAssertiveResult WithMetadata(string metadataName, object metadataValue);
        object GetMetadata(string metadataName);
        IResult Overload(BreakBehavior breakBehavior = BreakBehavior.Default);
        IResult<T> Override<T>(BreakBehavior breakBehavior = BreakBehavior.Default);
    }

    public interface IAssertiveResult<T> : IAssertiveResult
    {
        T Value { get; }

        new IAssertiveResult<T> WithMetadata(string metadataName, object metadataValue);
        new IResult<T> Overload(BreakBehavior breakBehavior = BreakBehavior.Default);
        new IResult<U> Override<U>(BreakBehavior breakBehavior = BreakBehavior.Default);
        IResult Override(BreakBehavior breakBehavior = BreakBehavior.Default);
    }
}