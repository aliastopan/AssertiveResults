namespace AssertiveResults.Assertions.Regex.Verbs
{
    public interface IValidates
    {
        IValidation Username(int min = 1, int max = 32);
        IValidation PasswordStrength();
        IValidation Email();
    }

    public interface IValidation
    {

    }
}