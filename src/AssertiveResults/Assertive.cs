using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public class Assertive : IAssertiveResult, IAssertive, IResult
    {
        private List<Error> _errors;

        public bool Success { get; protected internal set;}
        public bool Failed => !Success;
        public IReadOnlyCollection<Error> Errors => _errors.AsReadOnly();

        private Assertive()
        {
            _errors = new List<Error>();
        }

        public static IAssertive Result()
        {
            return new Assertive();
        }

        public IResult Assert(Action<Assertion> assert)
        {
            var assertion = new Assertion();
            assert?.Invoke(assertion);

            if(assertion.Fail)
            {
                _errors.Add(assertion.Error);
            }

            return this;
        }

        public IAssertiveResult Return()
        {
            return this;
        }
    }
}