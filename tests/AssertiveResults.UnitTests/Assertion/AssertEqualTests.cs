namespace AssertiveResults.UnitTests.Assertion;

public record MockRecord(int Id, string value);

public class AssertEqualTests
{
    [Fact]
    public void Should_Equal()
    {
        var result = Assertive.Result()
            .Assert(x => {
                var former = "text";
                var latter = "text";
                x.Should.Equal(former, latter);
            })
            .Assert(x => {
                var former = new MockRecord(5, "five");
                var latter = new MockRecord(5, "five");
                x.Should.Equal(former, latter);
            })
            .Finalize();

        Assert.True(result.Success);
    }

    [Fact]
    public void Should_NotEqual()
    {
        var result = Assertive.Result()
            .Assert(x => {
                var former = "text";
                var latter = "";
                x.Should.NotEqual(former, latter);
            })
            .Assert(x => {
                var former = new MockRecord(5, "five");
                var latter = new MockRecord(6, "six");
                x.Should.NotEqual(former, latter);
            })
            .Finalize();

        Assert.True(result.Success);
    }
}
