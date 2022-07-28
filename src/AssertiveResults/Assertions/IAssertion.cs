using System.Collections;

namespace AssertiveResults.Assertions
{
    public interface IAssertion
    {
        IAssert Satisfy(bool condition);
        IAssert NotSatisfy(bool condition);
        IAssert Null(object @object);
        IAssert NotNull(object @object);
        IAssert Empty(IEnumerable collection);
        IAssert NotEmpty(IEnumerable collection);
        IAssert Equal<T>(T former, T latter);
        IAssert NotEqual<T>(T former, T latter);
    }
}