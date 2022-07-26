namespace AssertiveResults.Assertions.Regex.Verbs
{
    public interface IValidates
    {
        IRegexAssert Username(int min = 1, int max = 32);
        IRegexAssert PasswordStrength();
        IRegexAssert Email();
    }
}