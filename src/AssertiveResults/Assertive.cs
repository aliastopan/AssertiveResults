using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public class Assertive : IAssertiveResult, IAssertive, IResult, IBreak
    {
        protected internal List<Error> errors;
        protected internal int counter;
        protected internal int breakPoint;

        public bool Success { get; protected internal set;}
        public bool Failed => !Success;
        public IReadOnlyCollection<Error> Errors => errors.AsReadOnly();
        public bool IsBreakPoint => counter > breakPoint && breakPoint != 0;
        public bool HasError => errors.Count > 0;

        protected Assertive()
        {
            errors = new List<Error>();
        }

        public static IAssertive Result()
        {
            return new Assertive();
        }

        public IResult Assert(Action<IAssertation> assert)
        {
            counter++;

            if(IsBreakPoint && HasError)
                return this;

            var assertion = new Assertation();
            assert?.Invoke(assertion);

            if(assertion.Failed)
                errors.AddRange(assertion.Errors);

            return this;
        }

        public IBreak Break()
        {
            breakPoint = counter;
            return this;
        }

        public IAssertiveResult Return()
        {
            if(!HasError)
                Success = true;

            return this;
        }

        public IAssertiveResult<T> Return<T>(T value, bool overwrite = false)
        {
            if(!HasError)
                Success = true;

            if(overwrite)
                return new Assertive<T>(value, this);

            value = Failed ? default : value;
            return new Assertive<T>(value, this);
        }
    }

    internal class Assertive<T> : Assertive, IAssertiveResult<T>
    {
        public T Value { get; internal set; }

        internal Assertive(T value, Assertive assertive)
        {
            this.errors = assertive.errors;
            this.counter = assertive.counter;
            this.breakPoint = assertive.breakPoint;
            this.Success = assertive.Success;
            Value = value;
        }
    }
}