using System;
using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion : IAssertion, IAssert
    {
        private readonly Assertation _assertation;

        internal Assertion(Assertation assertion)
        {
            _assertation = assertion;
        }

        public IAssert Satisfy(bool condition)
        {
            _assertation.IsSatisfied = condition;
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "Boolean.Assertion";
                var errorDescription = $"{_assertation.InputName} must satisfy the specified condition.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotSatisfy(bool condition)
        {
            _assertation.IsSatisfied = !condition;
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "Boolean.Assertion";
                var errorDescription = $"{_assertation.InputName} must not satisfy the illegal condition.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert Null(object @object)
        {
            _assertation.IsSatisfied = @object == null;
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "Null.Assertion";
                var errorDescription = $"{_assertation.InputName} must be null.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotNull(object @object)
        {
            _assertation.IsSatisfied = @object != null;
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "NotNull.Assertion";
                var errorDescription = $"{_assertation.InputName} must not be null.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert Empty(IEnumerable collection)
        {
            _assertation.IsSatisfied = !collection.GetEnumerator().MoveNext();
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "Empty.Assertion";
                var errorDescription = $"{_assertation.InputName} must be empty.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotEmpty(IEnumerable collection)
        {
            _assertation.IsSatisfied = collection.GetEnumerator().MoveNext();
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "NotEmpty.Assertion";
                var errorDescription = $"{_assertation.InputName} must not be empty.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert Equal<T>(T former, T latter)
        {
            _assertation.IsSatisfied = former.Equals(latter);
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "Equal.Assertion";
                var errorDescription = $"{_assertation.InputName}(s) must be equal.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotEqual<T>(T former, T latter)
        {
            _assertation.IsSatisfied = !former.Equals(latter);
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "NotEqual.Assertion";
                var errorDescription = $"{_assertation.InputName}(s) must not be equal.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert StrictEqual<T>(IComparable<T> former, T latter)
        {
            int result = former.CompareTo(latter);
            _assertation.IsSatisfied = result == 0;
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "StrictEqual.Assertion";
                var errorDescription = $"{_assertation.InputName}(s) must have identical values.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotStrictEqual<T>(IComparable<T> former, T latter)
        {
            int result = former.CompareTo(latter);
            _assertation.IsSatisfied = result != 0;
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "NotStrictEqual.Assertion";
                var errorDescription = $"{_assertation.InputName}(s) must not have identical values.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }
            return this;
        }

        public IAssert Same(object former, object latter)
        {
            _assertation.IsSatisfied = former == latter;
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "Equal.Assertion";
                var errorDescription = $"{_assertation.InputName}(s) must be the same instance.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotSame(object former, object latter)
        {
            _assertation.IsSatisfied = former != latter;
            if(!_assertation.IsSatisfied)
            {
                var errorCode = "Equal.Assertion";
                var errorDescription = $"{_assertation.InputName}(s) must not be the same instance.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertation.Errors.Add(error);
            }

            return this;
        }

        public IAssertion Otherwise(Error error)
        {
            if(_assertation.Failed)
            {
                _assertation.Errors.RemoveAt(_assertation.Errors.Count - 1);
                _assertation.Errors.Add(error);
            }

            return this;
        }
    }
}