using System.Collections.Generic;

namespace AssertiveResults.Contracts
{
    public interface IMetadata
    {
        IReadOnlyDictionary<string, object> Metadata { get; }
        bool HasMetadata { get; }

        IResult WithMetadata(string metadataName, object metadataValue);
        object GetMetadata(string metadataName);
    }

    public interface IMetadata<T> : IMetadata
    {
        new IResult<T> WithMetadata(string metadataName, object metadataValue);
    }
}