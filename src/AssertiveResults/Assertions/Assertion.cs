using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion
    {
        private bool _isSatisfied;
        public bool Fail => !_isSatisfied;
        public Error Error { get; private set; }

        public Assertion True(bool condition)
        {
            _isSatisfied = condition;
            if(Fail)
                Error = new Error();

            return this;
        }

        public Assertion False(bool condition)
        {
            _isSatisfied = !condition;
            if(Fail)
                Error = new Error();

            return this;
        }

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

        public Assertion WithError(string errorMessage)
        {
            Error = new Error(errorMessage);
            return this;
        }
    }
}