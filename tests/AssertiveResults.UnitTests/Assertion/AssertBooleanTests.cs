namespace AssertiveResults.UnitTests.Assertion;

public class AssertBooleanTests
{
    [Fact]
    public void Should_Satisfy()
    {
        var result = Assertive.Result()
            .Assert(x => x.Should.Satisfy(true))
            .Resolve();

        Assert.True(result.Success);
    }

    [Fact]
    public void Should_NotSatisfy()
    {
        var result = Assertive.Result()
            .Assert(x => x.Should.NotSatisfy(false))
            .Resolve();

        Assert.True(result.Success);
    }
}
