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
                var error = Error.Unspecified();
                _assertion.Errors.Add(error);
            }

            return this;
        }

        public IAssertMust NotSatisfy(bool condition)
        {
            _assertion.IsSatisfied = condition;
            if(!_assertion.IsSatisfied)
            {
                var error = Error.Unspecified();
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