using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion : IAssertion, IAssert
    {
        private Assertation _assertion;

        internal Assertion(Assertation assertion)
        {
            _assertion = assertion;
        }

        public IAssert Satisfy(bool condition)
        {
            _assertion.IsSatisfied = condition;
            if(!_assertion.IsSatisfied)
            {
                _assertion.ErrorCode = "Satisfy";
                var errorCode = $"Should.{_assertion.ErrorCode}";
                var errorDescription = $"{_assertion.InputName} did not satisfy the specified condition.";
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
                _assertion.ErrorCode = "NotSatisfy";
                var errorCode = $"Should.{_assertion.ErrorCode}";
                var errorDescription = $"{_assertion.InputName} satisfy the illegal condition.";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert Null(object @object)
        {
            _assertion.IsSatisfied = @object == null;
            if(!_assertion.IsSatisfied)
            {
                _assertion.ErrorCode = "Null";
                var errorCode = $"Should.{_assertion.ErrorCode}";
                var errorDescription = $"{_assertion.InputName} should not be null.";
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
                _assertion.ErrorCode = "NotNull";
                var errorCode = $"Should.{_assertion.ErrorCode}";
                var errorDescription = $"{_assertion.InputName} should be null.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert Equal(object former, object latter)
        {
            _assertion.IsSatisfied = former.Equals(latter);
            if(!_assertion.IsSatisfied)
            {
                _assertion.ErrorCode = "Equal";
                var errorCode = $"Should.{_assertion.ErrorCode}";
                var errorDescription = $"{_assertion.InputName}(s) should be equal.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert NotEqual(object former, object latter)
        {
            _assertion.IsSatisfied = !former.Equals(latter);
            if(!_assertion.IsSatisfied)
            {
                _assertion.ErrorCode = "NotEqual";
                var errorCode = $"Should.{_assertion.ErrorCode}";
                var errorDescription = $"{_assertion.InputName}(s) should not be equal.";
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
                _assertion.ErrorCode = "Empty";
                var errorCode = $"Should.{_assertion.ErrorCode}";
                var errorDescription = $"{_assertion.InputName} should be empty.";
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
                _assertion.ErrorCode = "NotEmpty";
                var errorCode = $"Should.{_assertion.ErrorCode}";
                var errorDescription = $"{_assertion.InputName} should not be emtpy.";
                var error = Error.Assertion(errorCode, errorDescription);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertion WithError(Error error)
        {
            if(!_assertion.IsSatisfied)
            {
                _assertion.Errors.RemoveAt(_assertion.Errors.Count - 1);
                _assertion.Errors.Add(error);
            }

            return this;
        }
    }
}