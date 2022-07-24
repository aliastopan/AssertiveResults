namespace AssertiveResults.Errors
{
    public struct Error
    {
        public ErrorType ErrorType { get; }
        public string Code { get; }
        public string Message { get; }

        private Error(ErrorType type, string code, string message)
        {
            ErrorType = type;
            Code = code;
            Message = message;
        }

        internal static Error Assertion(
            string code = "Assertion.Error",
            string message = "An assertion error has occured.")
        {
            return new Error(ErrorType.Failure, code, message);
        }

        public static Error Failure(
            string code = "General.Failure",
            string message = "A failure has occured.")
        {
            return new Error(ErrorType.Failure, code, message);
        }

        public static Error Conflict(
            string code = "General.Conflict",
            string message = "A conflict error has occured.")
        {
            return new Error(ErrorType.Conflict, code, message);
        }

        public static Error NotFound(
            string code = "General.NotFound",
            string message = "A 'Not Found' error has occured.")
        {
            return new Error(ErrorType.NotFound, code, message);
        }

        public static Error Unexpected(
            string code = "General.Unexpected",
            string message = "An unexpected error has occured.")
        {
            return new Error(ErrorType.Unexpected, code, message);
        }

        public static Error Validation(
            string code = "General.Validation",
            string message = "A validation error has occured.")
        {
            return new Error(ErrorType.Validation, code, message);
        }
    }
}