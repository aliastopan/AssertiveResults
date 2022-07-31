using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public class Assertive : IAssertiveResult, IAssertive, IResult, IBreak, IFinalize
    {
        protected internal List<Error> errors;
        protected internal int counter;
        protected internal int breakPoint;

        protected Assertive()
        {
            errors = new List<Error>();
        }

        public bool HasError => errors.Count > 0;
        public bool Success => errors.Count == 0;
        public bool Failed => !Success;
        public IReadOnlyCollection<Error> Errors => errors.AsReadOnly();

        public Error FirstError {
            get{
                if(!HasError)
                    throw new InvalidOperationException();

                return errors[0];
            }
        }

        public Error LastError {
            get{
                if(!HasError)
                    throw new InvalidOperationException();

                return errors[errors.Count - 1];
            }
        }

        public static IAssertive Result()
        {
            return new Assertive();
        }

        public IResult Assert(Action<IAssertation> context)
        {
            counter++;

            var isBreakPoint = counter > breakPoint && breakPoint != 0;
            if(isBreakPoint && HasError)
                return this;

            var assertation = new Assertation();
            context?.Invoke(assertation);

            if(assertation.Failed)
                errors.AddRange(assertation.Errors);

            return this;
        }

        public IBreak Break()
        {
            breakPoint = counter;
            return this;
        }

        public IAssertiveResult Finalize()
        {
            return this;
        }

        public IAssertiveResult<T> Finalize<T>(Func<IFinalize, T> result)
        {
            if(HasError)
                return new Assertive<T>(default, this);

            T value = result(this);
            return new Assertive<T>(value, this);
        }
    }

    internal class Assertive<T> : Assertive, IAssertiveResult<T>
    {
        internal Assertive(T value, Assertive assertive)
        {
            this.errors = assertive.errors;
            this.counter = assertive.counter;
            this.breakPoint = assertive.breakPoint;
            Value = Success ? value : default;
        }

        public T Value { get; internal set; }
    }
}