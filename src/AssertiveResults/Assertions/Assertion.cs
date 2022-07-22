using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions
{
    public class Assertion
    {
        private bool _isSatisfied;

        public List<Error> Errors { get; } = new List<Error>();
        public bool Failed => Errors.Count > 0;

        public Assertion Match(string input, Regex regex)
        {
            _isSatisfied = regex.IsMatch(input);
            if(!_isSatisfied)
                Errors.Add(new Error());

            return this;
        }

        public Assertion Match(string input, string pattern)
        {
            var regex = new Regex(pattern);
            return Match(input, regex);
        }

        public Assertion True(bool condition)
        {
            _isSatisfied = condition;
            if(!_isSatisfied)
                Errors.Add(new Error());

            return this;
        }

        public Assertion False(bool condition)
        {
            _isSatisfied = !condition;
            if(!_isSatisfied)
                Errors.Add(new Error());

            return this;
        }

        public Assertion Null(object @object)
        {
            _isSatisfied = @object == null;
            if(!_isSatisfied)
                Errors.Add(new Error());

            return this;
        }

        public Assertion NotNull(object @object)
        {
            _isSatisfied = @object != null;
            if(!_isSatisfied)
                Errors.Add(new Error());

            return this;
        }

        public Assertion Empty(IEnumerable collection)
        {
            _isSatisfied = !collection.GetEnumerator().MoveNext();
            return this;
        }

        public Assertion NotEmpty(IEnumerable collection)
        {
            _isSatisfied = collection.GetEnumerator().MoveNext();
            return this;
        }

        public Assertion WithError(string errorMessage)
        {
            if(!_isSatisfied)
                Errors.Last().Message = errorMessage;

            return this;
        }
    }
}