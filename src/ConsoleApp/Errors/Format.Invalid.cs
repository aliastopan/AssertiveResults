using AssertiveResults.Errors;

namespace ConsoleApp.Errors;

public static class Invalid
{
    public static Error PasswordFormat => Error.Invalid(
        "Password.Invalid",
        "Invalid password format.");

    public static Error UsernameTooShort => Error.Invalid(
        "Password.Invalid",
        "Invalid username too short.");

    public static Error UsernameTooLong => Error.Invalid(
        "Password.Invalid",
        "Invalid username too long.");

    public static Error UsernameLength => Error.Invalid(
        "Password.Invalid",
        "Invalid username length.");
}