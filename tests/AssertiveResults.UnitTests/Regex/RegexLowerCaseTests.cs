
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
                x.RegularExpression.Validate(input)
                    .Contains.LowerCase();
            })
            .Resolve();

        Assert.True(result.IsSuccess);
    }

    [Theory]
    [InlineData("NOT_LOWERCASE")]
    [InlineData("UPPERCASE!")]
    [InlineData("UPPER123")]
    public void Invalid_LowerCase(string input)
    {
        var result = Assertive.Result()
            .Assert(x => {
                x.RegularExpression.Validate(input)
                    .Contains.LowerCase();
            })
            .Resolve();

        Assert.True(result.HasFailed);
    }
}
