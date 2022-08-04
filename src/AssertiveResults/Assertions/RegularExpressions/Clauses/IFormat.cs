namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    public interface IFormat
    {
        IRegexAssert Username(int min = 1, int max = 32);
        IRegexAssert StrongPassword(PasswordStrength strength = PasswordStrength.Standard);
        IRegexAssert EmailAddress();
    }
}