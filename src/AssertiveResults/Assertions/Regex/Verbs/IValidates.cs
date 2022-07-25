namespace AssertiveResults.Assertions.Regex.Verbs
{
    public interface IValidates
    {
        IRegexAssertValidates Username();
        IRegexAssertValidates PasswordStrength();
        IRegexAssertValidates Email();
    }
}