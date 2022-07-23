using AssertiveResults;

namespace AssertiveResults.UnitTests;

public class AssertiveResultTest
{
    private ITestOutputHelper output;

    public AssertiveResultTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void AssertTest()
    {
        Assert.True(true);
    }
}
