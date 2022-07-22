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
        string user = null!;

        var result = Assertive.Result()
            .Assert(x => {
                x.NotNull(user);
            })
            .Assert(x => {
                x.NotNull(user);
            })
            .Return();

        Assert.True(true);
        output.WriteLine("Error(s): {0}", result.Errors.Count);
    }
}
