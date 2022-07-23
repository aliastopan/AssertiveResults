using System.Collections.Generic;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion : IAssert, IAssertion
    {
        public IAssertMust Must { get; internal set; }
        public IAssertRegex Regex { get; internal set; }
        internal List<Error> Errors { get; } = new List<Error>();
        internal bool IsSatisfied { get; set; }
        internal bool Failed => Errors.Count > 0;

        internal Assertion()
        {
            Must = new AssertMust(this);
            Regex = new AssertRegex(this);
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