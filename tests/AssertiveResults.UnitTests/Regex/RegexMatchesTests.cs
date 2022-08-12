namespace AssertiveResults.UnitTests.Regex;

public class RegexMatchesTests
{
    [Theory]
    [InlineData("NOT_LOWERCASE")]
    [InlineData("UPPERCASE!")]
    [InlineData("UPPER123")]
    public void MatchesUpperCaseTest(string input)
    {
       var result = Assertive.Result()
            .Assert(x => {
                x.RegularExpression.Validate(input).Matches("[A-Z]+");
            })
            .Resolve();
        Assert.True(true);
    }

    [Theory]
    [InlineData("lowercase")]
    [InlineData("lowerUPPER")]
    [InlineData("lower123")]
    [InlineData("aA")]
    public void MatchesLowerCaseTest(string input)
    {
        var result = Assertive.Result()
            .Assert(x => {
                x.RegularExpression.Validate(input).Matches("[a-z]+");
            })
            .Resolve();

        Assert.True(result.IsSuccess);
    }
}
