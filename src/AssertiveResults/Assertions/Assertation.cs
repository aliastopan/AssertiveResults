using System.Collections.Generic;
using AssertiveResults.Assertions.Regex;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertation : IAssertation
    {
        private const string INPUT_NAME = "Input";

        internal Assertation()
        {
            Should = new Assertion(this);
            Regex = new RegexAssertion(this);
        }

        public IAssertion Should { get; internal set; }
        public IRegex Regex { get; internal set; }
        internal List<Error> Errors { get; } = new List<Error>();
        internal bool IsSatisfied { get; set; }
        internal bool Failed => Errors.Count > 0;
        internal string InputName => INPUT_NAME;
    }
}