
namespace AssertiveResults.UnitTests.Regex;

public class RegexLowerCaseTests
{
   [Theory]
    [InlineData("lowercase")]
    [InlineData("lowerUPPER")]
    [InlineData("lower123")]
    [InlineData("aA")]
    public void Valid_LowerCase(string input)
    {
        var result = Assertive.Result()
            .Assert(x => {
                x.Regex.Match(input)
                    .Contains.LowerCase();
            })
            .Finalize();

        Assert.True(result.Success);
    }

    [Theory]
    [InlineData("NOT_LOWERCASE")]
    [InlineData("UPPERCASE!")]
    [InlineData("UPPER123")]
    public void Invalid_LowerCase(string input)
    {
        var result = Assertive.Result()
            .Assert(x => {
                x.Regex.Match(input)
                    .Contains.LowerCase();
            })
            .Finalize();

        Assert.True(result.Failed);
    }
}
