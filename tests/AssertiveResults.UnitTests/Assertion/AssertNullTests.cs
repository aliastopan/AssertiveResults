namespace AssertiveResults.UnitTests.Assertion;

public class AssertNullTests
{
    [Fact]
    public void Should_Null()
    {
        string user = null!;

        var result = Assertive.Result()
            .Assert(x => x.Should.Null(user))
            .Resolve();

        Assert.True(result.Success);
    }

    [Fact]
    public void Should_NotNull()
    {
        string user = "user";

        var result = Assertive.Result()
            .Assert(x => x.Should.NotNull(user))
            .Resolve();

        Assert.True(result.Success);
    }
}
