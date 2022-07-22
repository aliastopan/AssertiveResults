using AssertiveResults;

namespace AssertiveResults.UnitTests;

public class AssertiveResultTest
{
    [Fact]
    public void Test()
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
    }
}
