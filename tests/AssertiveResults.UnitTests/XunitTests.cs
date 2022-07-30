using AssertiveResults;

namespace AssertiveResults.UnitTests;

public class XunitTests
{
    private readonly ITestOutputHelper output;

    public XunitTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Test()
    {
        output.WriteLine("Out");
        Assert.True(true);
    }
}
