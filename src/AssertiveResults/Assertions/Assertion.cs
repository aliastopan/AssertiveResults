using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion : IMust
    {
        public Must Must { get; internal set; }
        internal List<Error> Errors { get; } = new List<Error>();
        internal bool IsSatisfied { get; set; }
        internal bool Failed => Errors.Count > 0;

        internal Assertion()
        {
            Must = new Must(this);
        }

        public Assertion Match(string input, Regex regex)
        {
            IsSatisfied = regex.IsMatch(input);
            if(!IsSatisfied)
                Errors.Add(new Error());

            return this;
        }

        public Assertion Match(string input, string pattern)
        {
            var regex = new Regex(pattern);
            return Match(input, regex);
        }

        public Assertion WithError(string errorMessage)
        {
            if(!IsSatisfied)
                Errors.Last().Message = errorMessage;

            return this;
        }
    }
}