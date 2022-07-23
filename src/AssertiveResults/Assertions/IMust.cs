using System.Collections;

namespace AssertiveResults.Assertions
{
    public interface IMust
    {
        IAssertion Satisfy(bool condition);
        IAssertion NotSatisfy(bool condition);
        IAssertion Null(object @object);
        IAssertion NotNull(object @object);
        IAssertion Empty(IEnumerable collection);
        IAssertion NotEmpty(IEnumerable collection);
        IAssertion Equal(object former, object latter);
        IAssertion NotEqual(object former, object latter);
    }
}