using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion
    {
        private bool _isSatisfied;
        public bool Fail => !_isSatisfied;
        public Error Error { get; private set; }

        public Assertion Null(object @object)
        {
            _isSatisfied = @object == null;
            if(Fail)
                Error = new Error();

            return this;
        }

        public Assertion NotNull(object @object)
        {
            _isSatisfied = @object != null;
            if(Fail)
                Error = new Error();

            return this;
        }
    }
}