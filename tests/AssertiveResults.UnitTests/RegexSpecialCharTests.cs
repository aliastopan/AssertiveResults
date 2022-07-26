using AssertiveResults;

namespace AssertiveResults.UnitTests;

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
    [InlineData(";")]
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
            .Return();

        Assert.True(result.Success);
    }
}
