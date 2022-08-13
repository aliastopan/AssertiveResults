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
                ErrorCode.Assertion.Boolean,
                ErrorDescription.UnsatisfiedCondition);
        }

        public IResult NotSatisfy(bool condition)
        {
            return Assert(!condition,
                ErrorCode.Assertion.Boolean,
                ErrorDescription.SatisfiedIllegalCondition);
        }

        public IResult Null(object @object)
        {
            return Assert(@object == null,
                ErrorCode.Assertion.ObjectReference,
                ErrorDescription.ReferenceIsNotNull);
        }

        public IResult NotNull(object @object)
        {
            return Assert(@object != null,
                ErrorCode.Assertion.ObjectReference,
                ErrorDescription.ReferenceIsNull);
        }

        public IResult Empty(IEnumerable collection)
        {
            return Assert(!collection.GetEnumerator().MoveNext(),
                ErrorCode.Assertion.Collection,
                ErrorDescription.CollectionIsNotEmpty);
        }

        public IResult NotEmpty(IEnumerable collection)
        {
            return Assert(collection.GetEnumerator().MoveNext(),
                ErrorCode.Assertion.Collection,
                ErrorDescription.CollectionIsEmpty);
        }

        public IResult Equal<T>(T former, T latter)
        {
            return Assert(former.Equals(latter),
                ErrorCode.Assertion.Value,
                ErrorDescription.ObjectsAreNotEqual);
        }

        public IResult NotEqual<T>(T former, T latter)
        {
            return Assert(!former.Equals(latter),
                ErrorCode.Assertion.Value,
                ErrorDescription.ObjectsAreEqual);
        }

        public IResult StrictEqual<T>(IComparable<T> former, T latter)
        {
            return Assert(former.CompareTo(latter) == 0,
                ErrorCode.Assertion.Value,
                ErrorDescription.ObjectsAreNotStrictlyEqual);
        }

        public IResult NotStrictEqual<T>(IComparable<T> former, T latter)
        {
            return Assert(former.CompareTo(latter) != 0,
                ErrorCode.Assertion.Value,
                ErrorDescription.ObjectsAreStrictlyEqual);
        }

        public IResult Same(object former, object latter)
        {
            return Assert(former == latter,
                ErrorCode.Assertion.ObjectReference,
                ErrorDescription.ReferencesNotAreTheSame);
        }

        public IResult NotSame(object former, object latter)
        {
            return Assert(former != latter,
                ErrorCode.Assertion.ObjectReference,
                ErrorDescription.ReferencesAreTheSame);
        }

        public IValueCheck WithError(IError error)
        {
            _context.WithError(error);
            return this;
        }

        internal IResult Assert(bool assertion, string errorCode, string errorMessages)
        {
            _context.AllCorrect = assertion;
            if(_context.AllCorrect)
                return this;

            _context.Errors.Add(Error.ValueCheck(errorCode, errorMessages));
            return this;
        }
    }
}