using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion : IAssert, IAssertion
    {
        public IMust Must { get; internal set; }
        public IRegex Regex { get; internal set; }
        internal List<Error> Errors { get; } = new List<Error>();
        internal bool IsSatisfied { get; set; }
        internal bool Failed => Errors.Count > 0;

        internal Assertion()
        {
            Must = new Must(this);
            Regex = new Regex(this);
        }

        public Assertion WithError(Error error)
        {
            if(!IsSatisfied)
            {
                Errors.RemoveAt(Errors.Count - 1);
                Errors.Add(error);
            }

            return this;
        }
    }
}