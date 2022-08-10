using System;
using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    internal sealed class Assertion : IAssertion, IAssert
    {
        private readonly Context _context;

        internal Assertion(Context context)
        {
            _context = context;
        }

        public IAssert Satisfy(bool condition)
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

        public IAssert NotSatisfy(bool condition)
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

        public IAssert Null(object @object)
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

        public IAssert NotNull(object @object)
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

        public IAssert Empty(IEnumerable collection)
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

        public IAssert NotEmpty(IEnumerable collection)
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

        public IAssert Equal<T>(T former, T latter)
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

        public IAssert NotEqual<T>(T former, T latter)
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

        public IAssert StrictEqual<T>(IComparable<T> former, T latter)
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

        public IAssert NotStrictEqual<T>(IComparable<T> former, T latter)
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

        public IAssert Same(object former, object latter)
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

        public IAssert NotSame(object former, object latter)
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

        public IAssertion WithError(Error error)
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