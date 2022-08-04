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
        protected internal BreakBehavior breakBehavior;

        protected Assertive()
        {
            errors = new List<Error>();
            metadata = new Dictionary<string, object>();
        }

        private Assertive(BreakBehavior breakBehavior)
        {
            errors = new List<Error>();
            metadata = new Dictionary<string, object>();
            this.breakBehavior = breakBehavior;
        }

        public bool HasError => errors.Count > 0;
        public bool HasMetadata => metadata.Count > 0;
        public bool Success => errors.Count == 0;
        public bool Failed => !Success;
        public IReadOnlyCollection<Error> Errors => errors.AsReadOnly();
        public IReadOnlyDictionary<string, object> Metadata => metadata;
        public Error FirstError => GetError(index: 0);
        public Error LastError => GetError(index: errors.Count - 1);

        public static IAssertive Result(BreakBehavior breakBehavior = BreakBehavior.Default)
        {
            if(breakBehavior == BreakBehavior.Default)
                breakBehavior = AssertiveResultSettings.Instance.DefaultBreakBehavior;

            return new Assertive(breakBehavior);
        }

        public static IAssertive<T> Result<T>(BreakBehavior breakBehavior = BreakBehavior.Default)
        {
            if(breakBehavior == BreakBehavior.Default)
                breakBehavior = AssertiveResultSettings.Instance.DefaultBreakBehavior;

            return new Assertive<T>(breakBehavior);
        }

        public IResult Assert(Action<IContext> context)
        {
            counter++;
            switch(breakBehavior)
            {
                case BreakBehavior.FirstError:
                {
                    if(HasError)
                        return this;

                    Assert();
                    return  this;
                }
                case BreakBehavior.Control:
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

        public IResult Extend(BreakBehavior breakBehavior = BreakBehavior.Default)
        {
            if(breakBehavior == BreakBehavior.Default)
                breakBehavior = AssertiveResultSettings.Instance.DefaultBreakBehavior;

            this.breakBehavior = breakBehavior;
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

        public IAssertiveResult<T> Resolve<T>(ResolveBehavior resolveBehavior, Func<IResolve, T> result)
        {
            switch(resolveBehavior)
            {
                case ResolveBehavior.Tolerant:
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

        private Error GetError(int index)
        {
            if(!HasError)
                throw new InvalidOperationException();

            return errors[index];
        }
    }

    internal class Assertive<T> : Assertive, IAssertiveResult<T>, IAssertive<T>, IResult<T>, IBreak<T>
    {
        internal Assertive(BreakBehavior breakBehavior)
        {
            this.breakBehavior = breakBehavior;
            Value = default;
        }

        internal Assertive(T value, Assertive assertive)
        {
            this.errors = assertive.errors;
            this.counter = assertive.counter;
            this.breakPoint = assertive.breakPoint;
            this.breakBehavior = assertive.breakBehavior;
            Value = !HasError ? value : default;
        }

        public T Value { get; internal set; }

        IResult<T> IAssertive<T>.Assert(Action<IContext> context)
        {
            return this;
        }

        IResult<T> IResult<T>.Assert(Action<IContext> context)
        {
            return this;
        }

        IResult<T> IBreak<T>.Assert(Action<IContext> context)
        {
            return this;
        }

        IBreak<T> IResult<T>.Break()
        {
            return this;
        }

        IAssertiveResult<T> IAssertiveResult<T>.WithMetadata(string metadataName, object metadataValue)
        {
            if(metadata.ContainsKey(metadataName))
                return this;

            metadata.Add(metadataName, metadataValue);
            return this;
        }
    }
}