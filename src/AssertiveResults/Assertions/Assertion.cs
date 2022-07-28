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
                var errorCode = $"{_assertion.InputName}.Boolean.Assertion";
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
                var errorCode = $"{_assertion.InputName}.Boolean.Assertion";
                var errorDescription = $"{_assertion.InputName} must not satisfy the illegal condition.";
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
                var errorCode = $"{_assertion.InputName}.Null.Assertion";
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
                var errorCode = $"{_assertion.InputName}.NotNull.Assertion";
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
                var errorCode = $"{_assertion.InputName}.Empty.Assertion";
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
                var errorCode = $"{_assertion.InputName}.NotEmpty.Assertion";
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
                var errorCode = $"{_assertion.InputName}.Equal.Assertion";
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
                var errorCode = $"{_assertion.InputName}.NotEqual.Assertion";
                var errorDescription = $"{_assertion.InputName}(s) must not be equal.";
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