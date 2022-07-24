using System.Collections;

namespace AssertiveResults.Assertions
{
    public interface IAssert
    {
        IAssertMust Satisfy(bool condition);
        IAssertMust NotSatisfy(bool condition);
        IAssertMust Null(object @object);
        IAssertMust NotNull(object @object);
        IAssertMust Equal(object former, object latter);
        IAssertMust NotEqual(object former, object latter);
        IAssertMust Empty(IEnumerable collection);
        IAssertMust NotEmpty(IEnumerable collection);
    }
}