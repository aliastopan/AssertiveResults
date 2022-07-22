using AssertiveResults.Errors;

namespace ConsoleApp.Errors;

public static class Invalid
{
    public static Error PasswordFormat => Error.Invalid(
        "Password.Invalid",
        "Invalid password format.");
}