using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;
using Behavior = AssertiveResults.ResolveBehavior;

namespace AssertiveResults
{
    public class Assertive : IResult, IExamine
    {
        protected internal List<IError> errors;
        protected internal Dictionary<string, object> metadata;

        protected Assertive()
        {
            errors = new List<IError>();
            metadata = new Dictionary<string, object>();
        }

        public bool IsSuccess => errors.Count == 0;
        public bool HasFailed => !IsSuccess;

        public IReadOnlyCollection<IError> Errors => errors.AsReadOnly();
        public IError FirstError => GetError(index: 0);
        public IError LastError => GetError(index: errors.Count - 1);
        public bool HasError => errors.Count > 0;

        public IReadOnlyDictionary<string, object> Metadata => metadata;
        public bool HasMetadata => metadata.Count > 0;

        public static IBegin Result()
        {
            return new Assertive();
        }

        public static IBegin<T> Result<T>()
        {
            return new Assertive<T>();
        }

        public ISubject Assert(Action<IContext> context)
        {
            if(HasError)
            {
                return this;
            }

            var ctx = new Context();
            context?.Invoke(ctx);

            if(ctx.HasError)
            {
                errors.AddRange(ctx.Errors);
            }

            return this;
        }

        public ISubject Overload()
        {
            return this;
        }

        public ISubject<T> Override<T>()
        {
            return new Assertive<T>(this);
        }

        public IResult Resolve()
        {
            return this;
        }

        public IResult Resolve(Action<IExamine> examine)
        {
            if(HasError)
            {
                return this;
            }

            examine?.Invoke(this);
            return this;
        }

        public IResult Resolve(Behavior behavior, Action<IExamine> examine)
        {
            switch(behavior)
            {
                case Behavior.Control:
                {
                    examine?.Invoke(this);
                    return this;
                }
                default:
                {
                    if(HasError)
                    {
                        return this;
                    }

                    examine?.Invoke(this);
                    return this;
                }
            }
        }

        public IResult WithMetadata(string metadataName, object metadataValue)
        {
            if(metadata.ContainsKey(metadataName))
            {
                return this;
            }

            metadata.Add(metadataName, metadataValue);
            return this;
        }

        public object GetMetadata(string metadataName)
        {
            metadata.TryGetValue(metadataName, out object value);
            return value;
        }

        public void Match(Action<IMetadata> onSuccess,
                          Action<(IProblem problem, IMetadata metadata)> onFailure)
        {
            if(HasError)
            {
                onFailure((this, this));
                return;
            }

            onSuccess(this);
        }

        public int PurgeErrors()
        {
            int count = errors.Count;
            errors.Clear();
            return count;
        }

        private IError GetError(int index)
        {
            if(!HasError)
            {
                throw new InvalidOperationException();
            }

            return errors[index];
        }
    }

    internal class Assertive<T> : Assertive, IResult<T>, IExamine<T>
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

        public new ISubject<T> Assert(Action<IContext> context)
        {
           if(HasError)
           {
                return this;
           }

            var ctx = new Context();
            context?.Invoke(ctx);

            if(ctx.HasError)
            {
                errors.AddRange(ctx.Errors);
            }

            return this;
        }

        public new ISubject<T> Overload()
        {
            return this;
        }

        public ISubject<U> Override<U>(out T value)
        {
            value = this.Value;
            return new Assertive<U>(this);
        }

        public ISubject Override(out T value)
        {
            value = this.Value;
            return this;
        }

        public IResult<T> Resolve(Func<IExamine<T>, T> examine)
        {
            Value = HasError ? default : examine(this);
            return this;
        }

        public IResult<T> Resolve(Behavior behavior, Func<IExamine<T>, T> examine)
        {
            switch(behavior)
            {
                case Behavior.Control:
                {
                    Value = examine(this);
                    return this;
                }
                default:
                {
                    if(HasError)
                    {
                        Value = default;
                        return this;
                    }

                    Value = examine(this);
                    return this;
                }
            }
        }

        public void Match(Action<(T value, IMetadata metadata)> onSuccess,
                          Action<(IProblem problem, IMetadata metadata)> onFailure)
        {
            if(HasError)
            {
                onFailure((this, this));
                return;
            }

            onSuccess((Value, this));
        }

        public U Match<U>(Func<(T value, IMetadata metadata), U> onSuccess,
                          Func<(IProblem problem, IMetadata metadata), U> onFailure)
        {
            if(HasError)
            {
                return onFailure((this, this));
            }

            return onSuccess((Value, this));
        }

        public new IResult<T> WithMetadata(string metadataName, object metadataValue)
        {
            if(metadata.ContainsKey(metadataName))
            {
                return this;
            }

            metadata.Add(metadataName, metadataValue);
            return this;
        }
    }
}