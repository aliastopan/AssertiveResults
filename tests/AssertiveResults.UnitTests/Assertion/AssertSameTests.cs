namespace AssertiveResults.UnitTests.Assertion;

public class AssertSameTests
{
    [Fact]
    public void Should_Same()
    {
        var result = Assertive.Result()
            .Assert(x => {
                var firstInstance = new List<string>() { "first" };
                var secondInstance = firstInstance;

                x.Should.Same(firstInstance, secondInstance);
            })
            .Resolve();

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Should_NotSame()
    {
        var result = Assertive.Result()
            .Assert(x => {
                var firstInstance = new List<string>() { "first" };
                var secondInstance = new List<string>() { "first" };

                x.Should.NotSame(firstInstance, secondInstance);
            })
            .Resolve();

        Assert.True(result.IsSuccess);
    }
}
