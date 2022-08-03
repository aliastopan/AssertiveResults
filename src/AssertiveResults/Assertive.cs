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
        protected internal BreakMethod breakMethod;

        protected Assertive()
        {
            errors = new List<Error>();
            metadata = new Dictionary<string, object>();
        }

        private Assertive(BreakMethod breakMethod)
        {
            errors = new List<Error>();
            metadata = new Dictionary<string, object>();
            this.breakMethod = breakMethod;
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

        public BreakMethod BreakMethod { get; }

        public static IAssertive Result(BreakMethod breakMethod = BreakMethod.Default)
        {
            if(breakMethod == BreakMethod.Default)
                breakMethod = AssertiveResultSettings.Instance.DefaultBreakMethod;

            return new Assertive(breakMethod);
        }

        public IResult Assert(Action<IContext> context)
        {
            counter++;
            switch(breakMethod)
            {
                case BreakMethod.FirstError:
                {
                    if(HasError)
                        return this;

                    Assert();
                    return  this;
                }
                case BreakMethod.Control:
                {
                    var isBreakPoint = counter > breakPoint && breakPoint != 0;
                    if(isBreakPoint && HasError)
                        return this;

                    Assert();
                    return this;
                }
                default:
                    throw new InvalidOperationException();
            }

            void Assert()
            {
                var ctx = new Context();
                context?.Invoke(ctx);

                if (ctx.Failed)
                    errors.AddRange(ctx.Errors);
            }
        }

        public IResult Extend()
        {
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

        public IAssertiveResult<T> Resolve<T>(Func<IResolve, T> result)
        {
            if(HasError)
                return new Assertive<T>(default, this);

            T value = result(this);
            return new Assertive<T>(value, this);
        }

        public IAssertiveResult<T> Resolve<T>(ResolveMethod resolveMethod, Func<IResolve, T> result)
        {
            switch(resolveMethod)
            {
                case ResolveMethod.Tolerant:
                    return Result();
                default:
                {
                    if(HasError)
                        return new Assertive<T>(default, this);
                    else
                        return Result();
                }
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

        public object GetMetadata(string metadataName)
        {
            metadata.TryGetValue(metadataName, out object value);
            return value;
        }
    }

    internal class Assertive<T> : Assertive, IAssertiveResult<T>
    {
        internal Assertive(T value, Assertive assertive)
        {
            this.errors = assertive.errors;
            this.counter = assertive.counter;
            this.breakPoint = assertive.breakPoint;
            this.breakMethod = assertive.breakMethod;
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