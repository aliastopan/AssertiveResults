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
                ErrorTitle.Assertion.Boolean,
                ErrorDetail.UnsatisfiedCondition);
        }

        public IResult NotSatisfy(bool condition)
        {
            return Assert(!condition,
                ErrorTitle.Assertion.Boolean,
                ErrorDetail.SatisfiedIllegalCondition);
        }

        public IResult Null(object @object)
        {
            return Assert(@object == null,
                ErrorTitle.Assertion.ObjectReference,
                ErrorDetail.ReferenceIsNotNull);
        }

        public IResult NotNull(object @object)
        {
            return Assert(@object != null,
                ErrorTitle.Assertion.ObjectReference,
                ErrorDetail.ReferenceIsNull);
        }

        public IResult Empty(IEnumerable collection)
        {
            return Assert(!collection.GetEnumerator().MoveNext(),
                ErrorTitle.Assertion.Collection,
                ErrorDetail.CollectionIsNotEmpty);
        }

        public IResult NotEmpty(IEnumerable collection)
        {
            return Assert(collection.GetEnumerator().MoveNext(),
                ErrorTitle.Assertion.Collection,
                ErrorDetail.CollectionIsEmpty);
        }

        public IResult Equal<T>(T former, T latter)
        {
            return Assert(former.Equals(latter),
                ErrorTitle.Assertion.Value,
                ErrorDetail.ObjectsAreNotEqual);
        }

        public IResult NotEqual<T>(T former, T latter)
        {
            return Assert(!former.Equals(latter),
                ErrorTitle.Assertion.Value,
                ErrorDetail.ObjectsAreEqual);
        }

        public IResult StrictEqual<T>(IComparable<T> former, T latter)
        {
            return Assert(former.CompareTo(latter) == 0,
                ErrorTitle.Assertion.Value,
                ErrorDetail.ObjectsAreNotStrictlyEqual);
        }

        public IResult NotStrictEqual<T>(IComparable<T> former, T latter)
        {
            return Assert(former.CompareTo(latter) != 0,
                ErrorTitle.Assertion.Value,
                ErrorDetail.ObjectsAreStrictlyEqual);
        }

        public IResult Same(object former, object latter)
        {
            return Assert(former == latter,
                ErrorTitle.Assertion.ObjectReference,
                ErrorDetail.ReferencesNotAreTheSame);
        }

        public IResult NotSame(object former, object latter)
        {
            return Assert(former != latter,
                ErrorTitle.Assertion.ObjectReference,
                ErrorDetail.ReferencesAreTheSame);
        }

        public IValueCheck WithError(IError error)
        {
            _context.WithError(error);
            return this;
        }

        public IValueCheck WithError(IError error, params object[] args)
        {
            _context.WithError(Error.FormatDetail(error, args));
            return this;
        }

        internal IResult Assert(bool assertion, string errorTitle, string errorDetail)
        {
            _context.AllCorrect = assertion;
            if(_context.AllCorrect)
                return this;

            _context.Errors.Add(Error.ValueCheck(errorTitle, errorDetail));
            return this;
        }
    }
}