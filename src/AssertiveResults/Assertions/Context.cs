using System.Collections.Generic;
using AssertiveResults.Assertions.Exception;
using AssertiveResults.Assertions.RegularExpressions;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Context : IContext
    {
        internal Context()
        {
            Should = new Assertion(this);
            RegularExpression = new RegexAssertion(this);
        }

        public IAssertion Should { get; internal set; }
        public IRegex RegularExpression { get; internal set; }
        public IException Exception { get; internal set; }

        internal List<Error> Errors { get; } = new List<Error>();
        internal bool IsSatisfied { get; set; }
        internal bool Failed => Errors.Count > 0;
    }
}