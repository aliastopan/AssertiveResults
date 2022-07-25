namespace AssertiveResults.Assertions.Regex.Verbs
{
    public interface IValidates
    {
        IValidatesAssert Username(int min = 1, int max = 32);
        IValidatesAssert PasswordStrength();
        IValidatesAssert Email();
    }

    public interface IValidatesAssert
    {

    }
}