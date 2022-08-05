using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;

namespace AssertiveResults
{
    public class Assertive : IAssertiveResult, IAssertive, IResult, IResolve
    {
        protected internal List<Error> errors;
        protected internal Dictionary<string, object> metadata;

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
        public Error FirstError => GetError(index: 0);
        public Error LastError => GetError(index: errors.Count - 1);

        public static IAssertive Result()
        {
            return new Assertive();
        }

        public static IAssertive<T> Result<T>()
        {
            return new Assertive<T>();
        }

        public IResult Assert(Action<IContext> context)
        {
            if(HasError)
                return this;

            var ctx = new Context();
            context?.Invoke(ctx);

            if(ctx.Failed)
                errors.AddRange(ctx.Errors);

            return this;
        }

        public IResult Overload()
        {
            return this;
        }

        public IResult<T> Override<T>()
        {
            return new Assertive<T>(this);
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

        public int PurgeErrors()
        {
            int count = errors.Count;
            errors.Clear();
            return count;
        }
    }

    internal class Assertive<T> : Assertive, IAssertiveResult<T>, IAssertive<T>, IResult<T>
    {
        internal Assertive()
        {
            Value = default;
        }

        internal Assertive(Assertive assertive)
        {
            this.errors = assertive.errors;
            this.metadata = assertive.metadata;
            Value = default;
        }

        public T Value { get; internal set; }

        public new IResult<T> Assert(Action<IContext> context)
        {
           if(HasError)
                return this;

            var ctx = new Context();
            context?.Invoke(ctx);
            if(ctx.Failed)
                errors.AddRange(ctx.Errors);

            return this;
        }

        public new IResult<T> Overload()
        {
            return this;
        }

        public new IResult<U> Override<U>()
        {
            return new Assertive<U>(this);
        }

        public IResult Override()
        {
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
                case ResolveBehavior.Control:
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