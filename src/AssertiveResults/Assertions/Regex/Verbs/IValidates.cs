namespace AssertiveResults.Assertions.Regex.Verbs
{
    public interface IValidates
    {
        IValidatesAssert Username();
        IValidatesAssert PasswordStrength();
        IValidatesAssert Email();
    }

    public interface IValidatesAssert
    {

    }
}