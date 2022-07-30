using System;
using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion : IAssertion, IAssert
    {
        private readonly Assertation _assertion;

        internal Assertion(Assertation assertion)
        {
            _assertion = assertion;
        }

        public IAssert Satisfy(bool condition)
        {
            _assertion.IsSatisfied = condition;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Boolean.Assertion";
                var errorDescription = $"{_assertion.InputName} must satisfy the specified condition.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotSatisfy(bool condition)
        {
            _assertion.IsSatisfied = !condition;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Boolean.Assertion";
                var errorDescription = $"{_assertion.InputName} must not satisfy the illegal condition.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert Null(object @object)
        {
            _assertion.IsSatisfied = @object == null;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Null.Assertion";
                var errorDescription = $"{_assertion.InputName} must be null.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotNull(object @object)
        {
            _assertion.IsSatisfied = @object != null;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "NotNull.Assertion";
                var errorDescription = $"{_assertion.InputName} must not be null.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert Empty(IEnumerable collection)
        {
            _assertion.IsSatisfied = !collection.GetEnumerator().MoveNext();
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Empty.Assertion";
                var errorDescription = $"{_assertion.InputName} must be empty.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotEmpty(IEnumerable collection)
        {
            _assertion.IsSatisfied = collection.GetEnumerator().MoveNext();
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "NotEmpty.Assertion";
                var errorDescription = $"{_assertion.InputName} must not be empty.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert Equal<T>(T former, T latter)
        {
            _assertion.IsSatisfied = former.Equals(latter);
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Equal.Assertion";
                var errorDescription = $"{_assertion.InputName}(s) must be equal.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotEqual<T>(T former, T latter)
        {
            _assertion.IsSatisfied = !former.Equals(latter);
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "NotEqual.Assertion";
                var errorDescription = $"{_assertion.InputName}(s) must not be equal.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert StrictEqual<T>(IComparable<T> former, T latter)
        {
            int result = former.CompareTo(latter);
            _assertion.IsSatisfied = result == 0;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "StrictEqual.Assertion";
                var errorDescription = $"{_assertion.InputName}(s) must have identical values.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotStrictEqual<T>(IComparable<T> former, T latter)
        {
            int result = former.CompareTo(latter);
            _assertion.IsSatisfied = result != 0;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "NotStrictEqual.Assertion";
                var errorDescription = $"{_assertion.InputName}(s) must not have identical values.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }
            return this;
        }

        public IAssert Same(object former, object latter)
        {
            _assertion.IsSatisfied = former == latter;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Equal.Assertion";
                var errorDescription = $"{_assertion.InputName}(s) must be the same instance.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotSame(object former, object latter)
        {
            _assertion.IsSatisfied = former != latter;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Equal.Assertion";
                var errorDescription = $"{_assertion.InputName}(s) must not be the same instance.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertion WithError(Error error)
        {
            ErrorHandler.WithError(_assertion, error);
            return this;
        }

        public IAssertion WithErrorDefault(string inputName = "Input", string errorCode = "")
        {
            ErrorHandler.WithErrorDefault(_assertion, inputName, errorCode);
            return this;
        }
    }
}