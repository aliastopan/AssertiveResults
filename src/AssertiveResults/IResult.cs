using System;
using System.Collections.Generic;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public interface IResult
    {
        IReadOnlyCollection<Error> Errors { get; }
        Error FirstError { get; }
        Error LastError { get; }

        IReadOnlyDictionary<string, object> Metadata { get; }
        bool HasMetadata { get; }

        bool Success { get; }
        bool Failed { get; }

        IResult WithMetadata(string metadataName, object metadataValue);
        object GetMetadata(string metadataName);
        ISubject Overload();
        ISubject<T> Override<T>();
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }

        new IResult<T> WithMetadata(string metadataName, object metadataValue);
        new ISubject<T> Overload();
        new ISubject<U> Override<U>();
        ISubject<U> Override<U>(out T value);
        ISubject Override();
        void Match(Action<T> onValue, Action<IProblem> onError);
        U Match<U>(Func<T, U> onValue, Func<IProblem, U> onError);
    }
}