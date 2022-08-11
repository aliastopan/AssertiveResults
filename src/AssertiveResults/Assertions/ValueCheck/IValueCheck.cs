using System;
using System.Collections;

namespace AssertiveResults.Assertions.ValueCheck
{
    public interface IValueCheck
    {
        IResult Satisfy(bool condition);
        IResult NotSatisfy(bool condition);
        IResult Null(object @object);
        IResult NotNull(object @object);
        IResult Empty(IEnumerable collection);
        IResult NotEmpty(IEnumerable collection);
        IResult Equal<T>(T former, T latter);
        IResult NotEqual<T>(T former, T latter);
        IResult StrictEqual<T>(IComparable<T> former, T latter);
        IResult NotStrictEqual<T>(IComparable<T> former, T latter);
        IResult Same(object former, object latter);
        IResult NotSame(object former, object latter);
    }
}