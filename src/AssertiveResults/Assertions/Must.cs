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
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public IAssertion NotSatisfy(bool condition)
        {
            _assertion.IsSatisfied = !condition;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public IAssertion Null(object @object)
        {
            _assertion.IsSatisfied = @object == null;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public IAssertion NotNull(object @object)
        {
            _assertion.IsSatisfied = @object != null;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public IAssertion Empty(IEnumerable collection)
        {
            _assertion.IsSatisfied = !collection.GetEnumerator().MoveNext();
            return _assertion;
        }

        public IAssertion NotEmpty(IEnumerable collection)
        {
            _assertion.IsSatisfied = collection.GetEnumerator().MoveNext();
            return _assertion;
        }
    }
}