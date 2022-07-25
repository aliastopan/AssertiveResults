namespace AssertiveResults.Assertions.Regex.Verbs
{
    public interface IValidates
    {
        IRegexAssert Username();
        IRegexAssert PasswordStrength();
        IRegexAssert Email();
    }
}