using AssertiveResults;

namespace AssertiveResults.UnitTests;

public class XunitTests
{
    private ITestOutputHelper output;

    public XunitTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Test()
    {
        Assert.True(true);
    }
}
