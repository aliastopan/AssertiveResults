using AssertiveResults.Errors;

namespace ConsoleApp.Errors;

public static class Invalid
{
    public static Error PasswordFormat => Error.Validation(
        "Password.Invalid",
        "Invalid password format.");

    public static Error UsernameTooShort => Error.Validation(
        "Password.Invalid",
        "Invalid username too short.");

    public static Error UsernameTooLong => Error.Validation(
        "Password.Invalid",
        "Invalid username too long.");

    public static Error UsernameLength => Error.Validation(
        "Password.Invalid",
        "Invalid username length.");
}