using System.Collections;

namespace AssertiveResults.Assertions
{
    public interface IAssertion
    {
        IAssert Satisfy(bool condition);
        IAssert NotSatisfy(bool condition);
        IAssert Null(object @object);
        IAssert NotNull(object @object);
        IAssert Equal(object former, object latter);
        IAssert NotEqual(object former, object latter);
        IAssert Empty(IEnumerable collection);
        IAssert NotEmpty(IEnumerable collection);
    }
}