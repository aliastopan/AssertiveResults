using System;
using System.Collections;
using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.ValueCheck
{
    internal sealed class Should : IValueCheck, IResult
    {
        private readonly Context _context;

        public Should(Context context)
        {
            _context = context;
        }

        public IResult Satisfy(bool condition)
        {
            return Assert(condition,
                "Boolean.ValueCheck",
                "Value must satisfy the specified condition.");
        }

        public IResult NotSatisfy(bool condition)
        {
            return Assert(!condition,
                "Boolean.ValueCheck",
                "Value must not satisfy the illegal condition.");
        }

        public IResult Null(object @object)
        {
            return Assert(@object == null,
                "Null.ValueCheck",
                "Value must be null.");
        }

        public IResult NotNull(object @object)
        {
            return Assert(@object != null,
                "NotNull.ValueCheck",
                "Value must not be null.");
        }

        public IResult Empty(IEnumerable collection)
        {
            return Assert(!collection.GetEnumerator().MoveNext(),
                "Empty.ValueCheck",
                "Value must be empty.");
        }

        public IResult NotEmpty(IEnumerable collection)
        {
            return Assert(collection.GetEnumerator().MoveNext(),
                "NotEmpty.ValueCheck",
                "Value must not be empty.");
        }

        public IResult Equal<T>(T former, T latter)
        {
            return Assert(former.Equals(latter),
                "Equal.ValueCheck",
                "Value(s) must be equal.");
        }

        public IResult NotEqual<T>(T former, T latter)
        {
            return Assert(!former.Equals(latter),
                "NotEqual.ValueCheck",
                "Value(s) must not be equal.");
        }

        public IResult StrictEqual<T>(IComparable<T> former, T latter)
        {
            return Assert(former.CompareTo(latter) == 0,
                "StrictEqual.ValueCheck",
                "Value(s) must have identical values.");
        }

        public IResult NotStrictEqual<T>(IComparable<T> former, T latter)
        {
            return Assert(former.CompareTo(latter) != 0,
                "NotStrictEqual.ValueCheck",
                "Value(s) must not have identical values.");
        }

        public IResult Same(object former, object latter)
        {
            return Assert(former == latter,
                "Same.ReferenceCheck",
                "Value(s) must be the same instance.");
        }

        public IResult NotSame(object former, object latter)
        {
            return Assert(former != latter,
                "NotSame.ReferenceCheck",
                "Value(s) must not be the same instance.");
        }

        public IValueCheck WithError(Error error)
        {
            if(_context.Failed)
            {
                _context.Errors.RemoveAt(_context.Errors.Count - 1);
                _context.Errors.Add(error);
            }

            return this;
        }

        internal IResult Assert(bool assertion, string errorCode, string errorMessages)
        {
            _context.IsSatisfied = assertion;
            if(_context.IsSatisfied)
                return this;

            _context.Errors.Add(Error.ValueCheck(errorCode, errorMessages));
            return this;
        }
    }
}