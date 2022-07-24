using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public class Assertive : IAssertiveResult, IAssertive, IResult, IBreak
    {
        protected internal List<Error> _errors;
        protected internal int _counter;
        protected internal int _breakPoint;

        public bool Success { get; protected internal set;}
        public bool Failed => !Success;
        public IReadOnlyCollection<Error> Errors => _errors.AsReadOnly();
        public bool IsBreakPoint => _counter > _breakPoint && _breakPoint != 0;
        public bool HasError => _errors.Count > 0;

        protected Assertive()
        {
            _errors = new List<Error>();
        }

        public static IAssertive Result()
        {
            return new Assertive();
        }

        public IResult Assert(Action<IAssertation> assert)
        {
            _counter++;

            if(IsBreakPoint && HasError)
            {
                return this;
            }

            var assertion = new Assertation();
            assert?.Invoke(assertion);

            if(assertion.Failed)
            {
                _errors.AddRange(assertion.Errors);
            }

            return this;
        }

        public IBreak Break()
        {
            _breakPoint = _counter;
            return this;
        }

        public IAssertiveResult Return()
        {
            if(!HasError)
                Success = true;

            return this;
        }

        public IAssertiveResult<T> Return<T>(T value)
        {
            return new Assertive<T>(value, this);
        }
    }

    internal class Assertive<T> : Assertive, IAssertiveResult<T>
    {
        public T Value { get; internal set; }

        internal Assertive(T value, Assertive assertive)
        {
            this._errors = assertive._errors;
            this._counter = assertive._counter;
            this._breakPoint = assertive._breakPoint;
            this.Success = assertive.Success;
            Value = Success ? value : default;
        }
    }
}