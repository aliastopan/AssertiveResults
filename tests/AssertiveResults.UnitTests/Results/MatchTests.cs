namespace AssertiveResults.UnitTests.Results;

public class MatchTests
{
    [Fact]
    public void MatchTest()
    {
        var result = Assertive.Result<string>()
            .Assert(ctx => ctx.Should.Satisfy(true))
            .Resolve(_ => "something");

        var value = result.Match(
            value => value + "-something",
            error => $"{error.FirstError.Description}");

        Assert.Equal("something-something", value);
    }
}
