namespace AssertiveResults.Errors
{
    public struct Error : IError
    {
        public ErrorType Type { get; }
        public int NumericType { get; }
        public string Title { get; }
        public string Detail { get; }

        private Error(ErrorType type, string title, string detail)
        {
            Type = type;
            NumericType = (int) type;
            Title = title;
            Detail = detail;
        }

        internal static Error ValueCheck(
            string title = ErrorTitle.Assertion.Value,
            string detail = ErrorDetail.ValueCheck)
        {
            return new Error(ErrorType.Failure, title, detail);
        }

        public static Error Failure(
            string title = ErrorTitle.Failure,
            string detail = ErrorDetail.Failure)
        {
            return new Error(ErrorType.Failure, title, detail);
        }

        public static Error Conflict(
            string title = ErrorTitle.Conflict,
            string detail = ErrorDetail.Conflict)
        {
            return new Error(ErrorType.Conflict, title, detail);
        }

        public static Error NotFound(
            string title = ErrorTitle.NotFound,
            string detail = ErrorDetail.NotFound)
        {
            return new Error(ErrorType.NotFound, title, detail);
        }

        public static Error Unexpected(
            string title = ErrorTitle.Unexpected,
            string detail = ErrorDetail.Unexpected)
        {
            return new Error(ErrorType.Unexpected, title, detail);
        }

        public static Error Validation(
            string title = ErrorTitle.Validation,
            string detail = ErrorDetail.Validation)
        {
            return new Error(ErrorType.Validation, title, detail);
        }

        public static Error Custom(
            int type,
            string title,
            string detail)
        {
            return new Error((ErrorType)type, title, detail);
        }
    }
}