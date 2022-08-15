using System.Security.Authentication;
using System.Net.Security;
using System.Net;
namespace AssertiveResults.Errors
{
    public enum ErrorType
    {
        Failure,
        Conflict,
        NotFound,
        Unexpected,
        Validation,
        Authentication,
        Authorization,
    }
}