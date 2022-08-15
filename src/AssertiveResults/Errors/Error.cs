using System.Net;

namespace AssertiveResults.Errors
{
    public struct Error : IError
    {
        private Error(ErrorType type, string status, string title, string detail)
        {
            Type = type;
            NumericType = (int) type;
            Status = status;
            Title = title;
            Detail = detail;
        }

        public ErrorType Type { get; }
        public int NumericType { get; }
        public string Title { get; }
        public string Status { get; }
        public string Detail { get; }

        internal static IError FormatDetail(IError error, params object[] args)
        {
            return new Error(
                error.Type,
                error.Status,
                error.Title,
                string.Format(error.Detail, args));
        }

        internal static Error ValueCheck(
            string status = "",
            string title = ErrorTitle.Assertion.Value,
            string detail = ErrorDetail.ValueCheck)
        {
            return new Error(ErrorType.Failure, status, title, detail);
        }

        public static Error Failure(
            string status = "",
            string title = ErrorTitle.Failure,
            string detail = ErrorDetail.Failure)
        {
            return new Error(ErrorType.Failure, status, title, detail);
        }

        public static Error Failure(
            int status = 0,
            string title = ErrorTitle.Failure,
            string detail = ErrorDetail.Failure)
        {
            return new Error(ErrorType.Failure, status.ToString(), title, detail);
        }

        public static Error Failure(
            HttpStatusCode status = HttpStatusCode.BadRequest,
            string title = ErrorTitle.Failure,
            string detail = ErrorDetail.Failure)
        {
            return Failure((int)status, title, detail);
        }

        public static Error Conflict(
            string status = "",
            string title = ErrorTitle.Conflict,
            string detail = ErrorDetail.Conflict)
        {
            return new Error(ErrorType.Conflict, status, title, detail);
        }

        public static Error Conflict(
            int status = 0,
            string title = ErrorTitle.Conflict,
            string detail = ErrorDetail.Conflict)
        {
            return new Error(ErrorType.Conflict, status.ToString(), title, detail);
        }

        public static Error Conflict(
            HttpStatusCode status = HttpStatusCode.Conflict,
            string title = ErrorTitle.Conflict,
            string detail = ErrorDetail.Conflict)
        {
            return Conflict((int)status, title, detail);
        }

        public static Error NotFound(
            string status = "",
            string title = ErrorTitle.NotFound,
            string detail = ErrorDetail.NotFound)
        {
            return new Error(ErrorType.NotFound, status, title, detail);
        }

        public static Error NotFound(
            int status = 0,
            string title = ErrorTitle.NotFound,
            string detail = ErrorDetail.NotFound)
        {
            return new Error(ErrorType.NotFound, status.ToString(), title, detail);
        }

        public static Error NotFound(
            HttpStatusCode status = HttpStatusCode.NotFound,
            string title = ErrorTitle.NotFound,
            string detail = ErrorDetail.NotFound)
        {
            return NotFound((int)status, title, detail);
        }

        public static Error Unexpected(
            string status = "",
            string title = ErrorTitle.Unexpected,
            string detail = ErrorDetail.Unexpected)
        {
            return new Error(ErrorType.Unexpected, status, title, detail);
        }

        public static Error Unexpected(
            int status = 0,
            string title = ErrorTitle.Unexpected,
            string detail = ErrorDetail.Unexpected)
        {
            return new Error(ErrorType.Unexpected, status.ToString(), title, detail);
        }

        public static Error Unexpected(
            HttpStatusCode status = HttpStatusCode.InternalServerError,
            string title = ErrorTitle.Unexpected,
            string detail = ErrorDetail.Unexpected)
        {
            return Unexpected((int)status, title, detail);
        }

        public static Error Validation(
            string status = "",
            string title = ErrorTitle.Validation,
            string detail = ErrorDetail.Validation)
        {
            return new Error(ErrorType.Validation, status, title, detail);
        }

        public static Error Validation(
            int status = 0,
            string title = ErrorTitle.Validation,
            string detail = ErrorDetail.Validation)
        {
            return new Error(ErrorType.Validation, status.ToString(), title, detail);
        }

        public static Error Validation(
            HttpStatusCode status = HttpStatusCode.Unauthorized,
            string title = ErrorTitle.Validation,
            string detail = ErrorDetail.Validation)
        {
            return Validation((int)status, title, detail);
        }

        public static Error Custom(
            int type,
            string status,
            string title,
            string detail)
        {
            return new Error((ErrorType)type, status, title, detail);
        }

        public static Error Custom(
            int type,
            int status,
            string title,
            string detail)
        {
            return new Error((ErrorType)type, status.ToString(), title, detail);
        }

        public static Error Custom(
            int type,
            HttpStatusCode status,
            string title,
            string detail)
        {
            return Custom(type, (int)status, title, detail);
        }
    }
}