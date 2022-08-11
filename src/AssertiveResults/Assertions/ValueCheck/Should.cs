using System;
using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.ValueCheck
{
    internal sealed class Should : IValueCheck, IResult
    {
        private readonly Context _context;

        public Should(Context context)
        {
            _context = context;
        }

        public IResult Satisfy(bool condition)
        {
            _context.IsSatisfied = condition;
            if(!_context.IsSatisfied)
            {
                const string errorCode = "Boolean.Assertion";
                const string errorDescription = "Value must satisfy the specified condition.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult NotSatisfy(bool condition)
        {
            _context.IsSatisfied = !condition;
            if(!_context.IsSatisfied)
            {
                const string errorCode = "Boolean.Assertion";
                const string errorDescription = "Value must not satisfy the illegal condition.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult Null(object @object)
        {
            _context.IsSatisfied = @object == null;
            if(!_context.IsSatisfied)
            {
                const string errorCode = "Null.Assertion";
                const string errorDescription = "Value must be null.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult NotNull(object @object)
        {
            _context.IsSatisfied = @object != null;
            if(!_context.IsSatisfied)
            {
                const string errorCode = "NotNull.Assertion";
                const string errorDescription = "Value must not be null.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult Empty(IEnumerable collection)
        {
            _context.IsSatisfied = !collection.GetEnumerator().MoveNext();
            if(!_context.IsSatisfied)
            {
                const string errorCode = "Empty.Assertion";
                const string errorDescription = "Value must be empty.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult NotEmpty(IEnumerable collection)
        {
            _context.IsSatisfied = collection.GetEnumerator().MoveNext();
            if(!_context.IsSatisfied)
            {
                const string errorCode = "NotEmpty.Assertion";
                const string errorDescription = "Value must not be empty.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult Equal<T>(T former, T latter)
        {
            _context.IsSatisfied = former.Equals(latter);
            if(!_context.IsSatisfied)
            {
                const string errorCode = "Equal.Assertion";
                const string errorDescription = "Value(s) must be equal.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult NotEqual<T>(T former, T latter)
        {
            _context.IsSatisfied = !former.Equals(latter);
            if(!_context.IsSatisfied)
            {
                const string errorCode = "NotEqual.Assertion";
                const string errorDescription = "Value(s) must not be equal.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult StrictEqual<T>(IComparable<T> former, T latter)
        {
            int result = former.CompareTo(latter);
            _context.IsSatisfied = result == 0;
            if(!_context.IsSatisfied)
            {
                const string errorCode = "StrictEqual.Assertion";
                const string errorDescription = "Value(s) must have identical values.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult NotStrictEqual<T>(IComparable<T> former, T latter)
        {
            int result = former.CompareTo(latter);
            _context.IsSatisfied = result != 0;
            if(!_context.IsSatisfied)
            {
                const string errorCode = "NotStrictEqual.Assertion";
                const string errorDescription = "Value(s) must not have identical values.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }
            return this;
        }

        public IResult Same(object former, object latter)
        {
            _context.IsSatisfied = former == latter;
            if(!_context.IsSatisfied)
            {
                const string errorCode = "Equal.Assertion";
                const string errorDescription = "Value(s) must be the same instance.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IResult NotSame(object former, object latter)
        {
            _context.IsSatisfied = former != latter;
            if(!_context.IsSatisfied)
            {
                const string errorCode = "Equal.Assertion";
                const string errorDescription = "Value(s) must not be the same instance.";
                var error = Error.Assertion(errorCode, errorDescription);
                _context.Errors.Add(error);
            }

            return this;
        }

        public IValueCheck WithError(Error error)
        {
            if(_context.Failed)
            {
                _context.Errors.RemoveAt(_context.Errors.Count - 1);
                _context.Errors.Add(error);
            }

            return this;
        }
    }
}