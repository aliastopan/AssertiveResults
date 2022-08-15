using System.Net;
using ErrorResult = AssertiveResults.Errors.Error;

namespace AssertiveResults.SampleTests.Errors;

public static partial class Error
{
    public static class Authentication
    {
        public static ErrorResult UserNotFound => ErrorResult
            .NotFound(
                status: HttpStatusCode.Unauthorized,
                title: "User.NotFound",
                detail: "User '{0}' not found.");

        public static ErrorResult IncorrectPassword => ErrorResult
            .Validation(
                status: HttpStatusCode.Unauthorized,
                title: "Password.Validation",
                detail: "Incorrect password.");
    }
}
