using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Must
    {
        private Assertion _assertion;

        internal Must(Assertion assertion)
        {
            _assertion = assertion;
        }

        public IMust Satisfy(bool condition)
        {
            _assertion.IsSatisfied = condition;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public IMust NotSatisfy(bool condition)
        {
            _assertion.IsSatisfied = !condition;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public IMust Null(object @object)
        {
            _assertion.IsSatisfied = @object == null;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public IMust NotNull(object @object)
        {
            _assertion.IsSatisfied = @object != null;
            if(!_assertion.IsSatisfied)
                _assertion.Errors.Add(new Error());

            return _assertion;
        }

        public IMust Empty(IEnumerable collection)
        {
            _assertion.IsSatisfied = !collection.GetEnumerator().MoveNext();
            return _assertion;
        }

        public IMust NotEmpty(IEnumerable collection)
        {
            _assertion.IsSatisfied = collection.GetEnumerator().MoveNext();
            return _assertion;
        }
    }
}