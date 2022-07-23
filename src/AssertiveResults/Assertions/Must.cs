using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Must : IMust
    {
        private Assertion _assertion;

        internal Must(Assertion assertion)
        {
            _assertion = assertion;
        }

        public IAssertion Satisfy(bool condition)
        {
            _assertion.IsSatisfied = condition;
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return _assertion;
        }

        public IAssertion NotSatisfy(bool condition)
        {
            _assertion.IsSatisfied = !condition;
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return _assertion;
        }

        public IAssertion Null(object @object)
        {
            _assertion.IsSatisfied = @object == null;
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return _assertion;
        }

        public IAssertion NotNull(object @object)
        {
            _assertion.IsSatisfied = @object != null;
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return _assertion;
        }

        public IAssertion Empty(IEnumerable collection)
        {
            _assertion.IsSatisfied = !collection.GetEnumerator().MoveNext();
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return _assertion;
        }

        public IAssertion NotEmpty(IEnumerable collection)
        {
            _assertion.IsSatisfied = collection.GetEnumerator().MoveNext();
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return _assertion;
        }

        public IAssertion Equal(object former, object latter)
        {
            _assertion.IsSatisfied = former.Equals(latter);
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return _assertion;
        }

        public IAssertion NotEqual(object former, object latter)
        {
            _assertion.IsSatisfied = !former.Equals(latter);
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return _assertion;
        }
    }
}