using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class AssertMust : IAssert, IAssertMust
    {
        private Assertion _assertion;

        internal AssertMust(Assertion assertion)
        {
            _assertion = assertion;
        }

        public IAssertMust Satisfy(bool condition)
        {
            _assertion.IsSatisfied = condition;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Must.Satisfy";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertMust NotSatisfy(bool condition)
        {
            _assertion.IsSatisfied = condition;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Must.NotSatisfy";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertMust Null(object @object)
        {
            _assertion.IsSatisfied = @object == null;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Must.Null";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertMust NotNull(object @object)
        {
            _assertion.IsSatisfied = @object != null;
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Must.NotNull";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertMust Equal(object former, object latter)
        {
            _assertion.IsSatisfied = former.Equals(latter);
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Must.Equal";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertMust NotEqual(object former, object latter)
        {
            _assertion.IsSatisfied = !former.Equals(latter);
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Must.NotEqual";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertMust Empty(IEnumerable collection)
        {
            _assertion.IsSatisfied = !collection.GetEnumerator().MoveNext();
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Must.Empty";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertMust NotEmpty(IEnumerable collection)
        {
            _assertion.IsSatisfied = collection.GetEnumerator().MoveNext();
            if(!_assertion.IsSatisfied)
            {
                var errorCode = "Must.NotEmpty";
                var error = Error.Assertion(errorCode);
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssert WithError(Error error)
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