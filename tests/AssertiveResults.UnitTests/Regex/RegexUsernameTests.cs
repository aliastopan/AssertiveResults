namespace AssertiveResults.UnitTests.Regex.Regex;

public class RegexUsernameTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("..")]
    [InlineData("._")]
    [InlineData("__")]
    [InlineData("xy")]
    [InlineData(".user")]
    [InlineData("_user")]
    [InlineData("user.")]
    [InlineData("user_")]
    [InlineData("user..name")]
    [InlineData("user._name")]
    [InlineData("user_.name")]
    [InlineData("user__name")]
    [InlineData("WayTooLongPassword")]
    public void InvalidUsernameTest(string username)
    {
        var result = Assertive.Result()
            .Assert(x => x.Regex.Match(username).Validates.Username(3, 12))
            .Finalize();

        Assert.True(result.Failed);
    }

    [Theory]
    [InlineData("user.name")]
    [InlineData("user_name")]
    [InlineData("username123")]
    [InlineData("username.123")]
    [InlineData("123username")]
    [InlineData("123.username")]
    [InlineData("UserName")]
    [InlineData("Username")]
    [InlineData("twelveschars")]
    public void ValidUsernameTest(string username)
    {
        var result = Assertive.Result()
            .Assert(x => x.Regex.Match(username).Validates.Username(3, 12))
            .Finalize();

        Assert.True(result.Success);
    }
}
