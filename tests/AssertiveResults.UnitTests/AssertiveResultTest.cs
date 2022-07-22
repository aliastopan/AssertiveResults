using AssertiveResults;

namespace AssertiveResults.UnitTests;

public class AssertiveResultTest
{
    [Fact]
    public void Test()
    {
        var result = Assertive.Result();

        Assert.True(true);
    }
}
