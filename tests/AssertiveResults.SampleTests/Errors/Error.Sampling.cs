using System.Net;
using AssertiveResults.Errors;
using ErrorResult = AssertiveResults.Errors.Error;

namespace AssertiveResults.SampleTests.Errors;

public static partial class Error
{
    public static class Sampling
    {
        public static IError First => ErrorResult
            .NotFound(
                status: HttpStatusCode.BadRequest,
                title: "Error.First",
                detail: "First error.");

        public static IError Second => ErrorResult
            .NotFound(
                status: HttpStatusCode.BadRequest,
                title: "Error.Second",
                detail: "Second error.");

        public static IError Third => ErrorResult
            .NotFound(
                status: HttpStatusCode.BadRequest,
                title: "Error.Third",
                detail: "Third error.");
    }
}
