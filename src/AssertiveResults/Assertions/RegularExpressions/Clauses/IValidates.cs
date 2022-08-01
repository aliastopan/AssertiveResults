using Strength = AssertiveResults.PasswordStrength;

namespace AssertiveResults.Assertions.RegularExpressions.Clauses
{
    public interface IValidates
    {
        IRegexAssert Username(int min = 1, int max = 32);
        IRegexAssert PasswordStrength(PasswordStrength strength = Strength.Standard);
        IRegexAssert Email();
    }
}