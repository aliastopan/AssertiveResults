using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;
using AssertiveResults.Settings;

namespace AssertiveResults
{
    public class Assertive : IAssertiveResult, IAssertive, IResult, IBreak, IResolve
    {
        protected internal List<Error> errors;
        protected internal Dictionary<string, object> metadata;
        protected internal int counter;
        protected internal int breakPoint;

        protected Assertive()
        {
            errors = new List<Error>();
            metadata = new Dictionary<string, object>();
        }

        public bool HasError => errors.Count > 0;
        public bool HasMetadata => metadata.Count > 0;
        public bool Success => errors.Count == 0;
        public bool Failed => !Success;
        public IReadOnlyCollection<Error> Errors => errors.AsReadOnly();
        public IReadOnlyDictionary<string, object> Metadata => metadata;

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

        public IAssertiveResult Resolve()
        {
            return this;
        }

        public IAssertiveResult<T> Resolve<T>(Func<IResolve, T> result, ResolveMethod resolveMethod = ResolveMethod.Default)
        {
            if(resolveMethod == ResolveMethod.Default)
                resolveMethod = AssertiveResultSettings.Instance.DefaultResolveMethod;

            switch(resolveMethod)
            {
                case ResolveMethod.Loose:
                    return Result();
                case ResolveMethod.Strict:
                {
                    if(HasError)
                        return new Assertive<T>(default, this);
                    else
                        return Result();
                }
                default:
                    throw new InvalidOperationException();
            }

            IAssertiveResult<T> Result()
            {
                T value = result(this);
                return new Assertive<T>(value, this);
            }
        }

        public IAssertiveResult WithMetadata(string metadataName, object metadataValue)
        {
            if(metadata.ContainsKey(metadataName))
                return this;

            metadata.Add(metadataName, metadataValue);
            return this;
        }
    }

    internal class Assertive<T> : Assertive, IAssertiveResult<T>
    {
        internal Assertive(T value, Assertive assertive)
        {
            this.errors = assertive.errors;
            this.counter = assertive.counter;
            this.breakPoint = assertive.breakPoint;
            Value = !HasError ? value : default;
        }

        public T Value { get; internal set; }

        IAssertiveResult<T> IAssertiveResult<T>.WithMetadata(string metadataName, object metadataValue)
        {
            if(metadata.ContainsKey(metadataName))
                return this;

            metadata.Add(metadataName, metadataValue);
            return this;
        }
    }
}