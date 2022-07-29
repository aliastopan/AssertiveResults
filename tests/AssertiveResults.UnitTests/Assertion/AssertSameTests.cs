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
            .Return();

        Assert.True(result.Success);
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
            .Return();

        Assert.True(result.Success);
    }
}
