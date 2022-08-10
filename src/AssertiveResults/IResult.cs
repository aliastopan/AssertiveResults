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
        IStep Overload();
        IStep<T> Override<T>();
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }

        new IResult<T> WithMetadata(string metadataName, object metadataValue);
        new IStep<T> Overload();
        new IStep<U> Override<U>();
        IStep<U> Override<U>(out T value);
        IStep Override();
        void Match(Action<T> onValue, Action<IError> onError);
        U Match<U>(Func<T, U> onValue, Func<IError, U> onError);
    }
}