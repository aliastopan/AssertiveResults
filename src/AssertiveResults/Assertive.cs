using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public class Assertive : IAssertiveResult, IAssertive, IResult, IBreakPoint
    {
        private List<Error> _errors;
        private int _counter;
        private int _breakPoint;

        public bool Success { get; protected internal set;}
        public bool Failed => !Success;
        public IReadOnlyCollection<Error> Errors => _errors.AsReadOnly();
        public bool IsBreakPoint => _counter > _breakPoint && _breakPoint != 0;
        public bool HasError => _errors.Count > 0;

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
            _counter++;

            if(IsBreakPoint && HasError)
            {
                return this;
            }

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
            if(!HasError)
                Success = true;

            return this;
        }

        public IBreakPoint Break()
        {
            _breakPoint = _counter;
            return this;
        }
    }
}