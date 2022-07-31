namespace AssertiveResults.UnitTests.Regex;

public class RegexSpecialCharTests
{
    [Theory]
    [InlineData("~")]
    [InlineData("!")]
    [InlineData("@")]
    [InlineData("#")]
    [InlineData("$")]
    [InlineData("%")]
    [InlineData("^")]
    [InlineData("&")]
    [InlineData("*")]
    [InlineData("(")]
    [InlineData(")")]
    [InlineData("_")]
    [InlineData("+")]
    [InlineData("-")]
    [InlineData("=")]
    [InlineData("[")]
    [InlineData("]")]
    [InlineData("{")]
    [InlineData("}")]
    [InlineData("\\")]
    [InlineData("|")]
    [InlineData(";")]
    [InlineData(":")]
    [InlineData("'")]
    [InlineData(@"""")]
    [InlineData("<")]
    [InlineData(">")]
    [InlineData(",")]
    [InlineData(".")]
    [InlineData("/")]
    [InlineData("?")]
    public void SpecialCharTest(string input)
    {
        var result = Assertive.Result()
            .Assert(x => {
                x.Regex.Match(input)
                    .Contains.Symbol();
            })
            .Resolve();

        Assert.True(result.Success);
    }
}
