namespace AssertiveResults.UnitTests.Regex;

public class RegexUpperCaseTests
{
    [Theory]
    [InlineData("NOT_LOWERCASE")]
    [InlineData("UPPERCASE!")]
    [InlineData("UPPER123")]
    public void Valid_UpperCase(string input)
    {
        var result = Assertive.Result()
            .Assert(x => {
                x.RegularExpression.Validate(input)
                    .Contains.UpperCase();
            })
            .Resolve();

        Assert.True(result.IsSuccess);
    }

    [Theory]
    [InlineData("lowercase")]
    [InlineData("lower")]
    [InlineData("lower123")]
    [InlineData("a")]
    [InlineData("&lower!")]
    public void Invalid_UpperCase(string input)
    {
        var result = Assertive.Result()
            .Assert(x => {
                x.RegularExpression.Validate(input)
                    .Contains.UpperCase();
            })
            .Resolve();

        Assert.True(result.HasFailed);
    }
}
