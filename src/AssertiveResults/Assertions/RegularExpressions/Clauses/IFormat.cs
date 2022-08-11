namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    public interface IFormat
    {
        IResult Username(int min = 1, int max = 32);
        IResult StrongPassword(PasswordStrength strength = PasswordStrength.Standard);
        IResult EmailAddress();
    }
}