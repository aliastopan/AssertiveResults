using System.Collections.Generic;
using AssertiveResults.Assertions.Exception;
using AssertiveResults.Assertions.RegularExpressions;
using AssertiveResults.Assertions.ValueCheck;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    internal sealed class Context : IContext
    {
        internal Context()
        {
            Should = new Should(this);
            RegularExpression = new Regex(this);
            Exception = new ErrorHandler(this);
        }

        public IValueCheck Should { get; internal set; }
        public IRegex RegularExpression { get; internal set; }
        public IErrorHandler Exception { get; internal set; }

        internal List<Error> Errors { get; } = new List<Error>();
        internal bool IsSatisfied { get; set; }
        internal bool Failed => Errors.Count > 0;
    }
}