using System.Collections.Generic;
using System.Linq;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion : IAssert, IMust, IRegex
    {
        public Must Must { get; internal set; }
        public Regex Regex { get; internal set; }
        internal List<Error> Errors { get; } = new List<Error>();
        internal bool IsSatisfied { get; set; }
        internal bool Failed => Errors.Count > 0;

        internal Assertion()
        {
            Must = new Must(this);
            Regex = new Regex(this);
        }

        public Assertion WithError(string errorMessage)
        {
            if(!IsSatisfied)
                Errors.Last().Message = errorMessage;

            return this;
        }
    }
}