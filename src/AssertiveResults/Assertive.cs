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

        public IResult Overload(BreakBehavior breakBehavior = BreakBehavior.Default)
        {
            if(breakBehavior == BreakBehavior.Default)
                breakBehavior = AssertiveResultSettings.Instance.DefaultBreakBehavior;

            this.breakBehavior = breakBehavior;
            return this;
        }

        public IResult<T> Override<T>(BreakBehavior breakBehavior = BreakBehavior.Default)
        {
            if(breakBehavior == BreakBehavior.Default)
                breakBehavior = AssertiveResultSettings.Instance.DefaultBreakBehavior;

            return new Assertive<T>(this, breakBehavior);
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

        internal Assertive(Assertive assertive, BreakBehavior breakBehavior)
        {
            this.errors = assertive.errors;
            this.counter = assertive.counter;
            this.breakPoint = assertive.breakPoint;
            this.breakBehavior = breakBehavior;
            Value = default;
        }

        public T Value { get; internal set; }

        public new IResult<T> Assert(Action<IContext> context)
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

        public new IResult<T> Overload(BreakBehavior breakBehavior = BreakBehavior.Default)
        {
            if(breakBehavior == BreakBehavior.Default)
                breakBehavior = AssertiveResultSettings.Instance.DefaultBreakBehavior;

            this.breakBehavior = breakBehavior;
            return this;
        }

        public new IResult<U> Override<U>(BreakBehavior breakBehavior = BreakBehavior.Default)
        {
            if(breakBehavior == BreakBehavior.Default)
                breakBehavior = AssertiveResultSettings.Instance.DefaultBreakBehavior;

            return new Assertive<U>(this, breakBehavior);
        }

        public IResult Override(BreakBehavior breakBehavior = BreakBehavior.Default)
        {
            return this;
        }

        public new IBreak<T> Break()
        {
            breakPoint = counter;
            return this;
        }

        public IAssertiveResult<T> Resolve(Func<IResolve, T> result)
        {
            Value = HasError ? default : result(this);
            return this;
        }

        public IAssertiveResult<T> Resolve(ResolveBehavior resolveBehavior, Func<IResolve, T> result)
        {
            switch(resolveBehavior)
            {
                case ResolveBehavior.Tolerant:
                    return Result();
                default:
                {
                    if(HasError)
                        return this;
                    else
                        return Result();
                }
            }

            IAssertiveResult<T> Result()
            {
                Value = result(this);
                return this;
            }
        }

        public new IAssertiveResult<T> WithMetadata(string metadataName, object metadataValue)
        {
            if(metadata.ContainsKey(metadataName))
                return this;

            metadata.Add(metadataName, metadataValue);
            return this;
        }
    }
}