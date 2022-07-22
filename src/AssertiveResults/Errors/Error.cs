namespace AssertiveResults.Errors
{
    public struct Error
    {
        public ErrorType ErrorType { get; }
        public string Message { get; }

        private Error(ErrorType errorType, string message)
        {
            ErrorType = errorType;
            Message = message;
        }

        public static Error Failure(string message = "A failure has occured.")
        {
            return new Error(ErrorType.Failure, message);
        }

        public static Error Conflict(string message = "A conflict error has occured.")
        {
            return new Error(ErrorType.Conflict, message);
        }

        public static Error NotFound(string message = "A 'Not Found' error has occured.")
        {
            return new Error(ErrorType.NotFound, message);
        }

        public static Error Unexpected(string message = "An unexpected error has occured.")
        {
            return new Error(ErrorType.Unexpected, message);
        }

        public static Error Validation(string message = "A validation error has occured.")
        {
            return new Error(ErrorType.Validation, message);
        }
    }
}