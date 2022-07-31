namespace AssertiveResults.UnitTests.Assertion;

public class AssertEmptyTests
{
    [Fact]
    public void Should_Empty()
    {
        var result = Assertive.Result()
            .Assert(x => {
                var listString = new List<string>();
                var listInt = new List<int>();
                var string1 = "";
                var string2 = string.Empty;

                x.Should.Empty(listString);
                x.Should.Empty(listInt);
                x.Should.Empty(string1);
                x.Should.Empty(string2);
            })
            .Resolve();

        Assert.True(result.Success);
    }

    [Fact]
    public void Should_NotEmpty()
    {
        var result = Assertive.Result()
            .Assert(x => {
                var listString = new List<string>() { "Text" };
                var listInt = new List<int>() { 5 };
                var string1 = "Text";
                var string2 = string.Empty;
                string2 = string1;

                x.Should.NotEmpty(listString);
                x.Should.NotEmpty(listInt);
                x.Should.NotEmpty(string1);
                x.Should.NotEmpty(string2);
            })
            .Resolve();

        Assert.True(result.Success);
    }
}
