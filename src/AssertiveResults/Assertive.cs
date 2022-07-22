
using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public class Assertive : IAssertiveResult
    {
        private List<Error> _errors;

        public bool Success { get; protected internal set;}
        public bool Failed => !Success;
        public IReadOnlyCollection<Error> Errors => _errors.AsReadOnly();
    }
}