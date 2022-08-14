using System;
using System.Collections.Generic;
using AssertiveResults.Assertions;
using AssertiveResults.Contracts;
using AssertiveResults.Errors;
using Behavior = AssertiveResults.ResolveBehavior;

namespace AssertiveResults
{
    public class Assertive : IResult, IInspect
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
                return this;

            var ctx = new Context();
            context?.Invoke(ctx);

            if(ctx.HasError)
                errors.AddRange(ctx.Errors);

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

        public IResult Resolve(Action<IInspect> context)
        {
            if(!HasError)
                context?.Invoke(this);

            return this;
        }

        public IResult Resolve(Behavior behavior, Action<IInspect> context)
        {
            switch(behavior)
            {
                case Behavior.Control:
                    context?.Invoke(this);
                    break;
                default:
                {
                    if (!HasError)
                        break;

                    context?.Invoke(this);
                    break;
                }
            }

            return this;
        }

        public IResult WithMetadata(string metadataName, object metadataValue)
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

        private IError GetError(int index)
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

        public void Match(Action<IMetadata> onSuccess,
                          Action<(IMetadata metadata, IProblem problem)> onFailure)
        {
            if(HasError)
                onSuccess(this);
            else
                onFailure((this, this));
        }
    }

    internal class Assertive<T> : Assertive, IResult<T>
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
                return this;

            var ctx = new Context();
            context?.Invoke(ctx);
            if(ctx.HasError)
                errors.AddRange(ctx.Errors);

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

        public IResult<T> Resolve(Func<IInspect, T> context)
        {
            Value = HasError ? default : context(this);
            return this;
        }

        public IResult<T> Resolve(Behavior behavior, Func<IInspect, T> context)
        {
            switch(behavior)
            {
                case Behavior.Control:
                    return Result();
                default:
                {
                    if(HasError)
                        return this;

                    return Result();
                }
            }

            IResult<T> Result()
            {
                Value = context(this);
                return this;
            }
        }

        public void Match(Action<T> onValue,
                          Action<IProblem> onError)
        {
            if(HasError)
                onError(this);
            else
                onValue(Value);
        }

        public void Match(Action<(T value, IMetadata metadata)> onSuccess,
                          Action<(IMetadata metadata, IProblem problem)> onFailure)
        {
            if(HasError)
                onFailure((this, this));
            else
                onSuccess((Value, this));
        }

        public U Match<U>(Func<(T value, IMetadata metadata), U> onSuccess,
                          Func<(IMetadata metadata, IProblem problem), U> onFailure)
        {
            if(HasError)
                return onFailure((this, this));

            return onSuccess((Value, this));
        }

        public new IResult<T> WithMetadata(string metadataName, object metadataValue)
        {
            if(metadata.ContainsKey(metadataName))
                return this;

            metadata.Add(metadataName, metadataValue);
            return this;
        }
    }
}