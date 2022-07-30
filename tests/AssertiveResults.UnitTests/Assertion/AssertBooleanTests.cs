namespace AssertiveResults.UnitTests.Assertion;

public class AssertBooleanTests
{
    [Fact]
    public void Should_Satisfy()
    {
        var result = Assertive.Result()
            .Assert(x => x.Should.Satisfy(true))
            .Finalize();

        Assert.True(result.Success);
    }

    [Fact]
    public void Should_NotSatisfy()
    {
        var result = Assertive.Result()
            .Assert(x => x.Should.NotSatisfy(false))
            .Finalize();

        Assert.True(result.Success);
    }
}
