using AssertiveResults.Errors;

namespace ConsoleApp.Errors;

public static class Conflict
{
    public static Error UsernameTaken => Error.Conflict(
        "Username.Taken",
        "Username is already taken.");

    public static Error EmailInUse => Error.Conflict(
        "Email.InUse",
        "Email is already in use.");
}
