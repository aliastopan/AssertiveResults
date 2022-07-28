namespace AssertiveResults.Errors
{
    public struct Error
    {
        public ErrorType ErrorType { get; }
        public int NumericType { get; }
        public string Code { get; }
        public string Description { get; }

        private Error(ErrorType type, string code, string description)
        {
            ErrorType = type;
            NumericType = (int) type;
            Code = code;
            Description = description;
        }

        internal static Error Assertion(
            string code = "Assertion.Error",
            string description = "An assertion error has occured.")
        {
            return new Error(ErrorType.Assertion, code, description);
        }

        public static Error Failure(
            string code = "General.Failure",
            string description = "A failure has occured.")
        {
            return new Error(ErrorType.Failure, code, description);
        }

        public static Error Conflict(
            string code = "General.Conflict",
            string description = "A conflict error has occured.")
        {
            return new Error(ErrorType.Conflict, code, description);
        }

        public static Error NotFound(
            string code = "General.NotFound",
            string description = "A 'Not Found' error has occured.")
        {
            return new Error(ErrorType.NotFound, code, description);
        }

        public static Error Unexpected(
            string code = "General.Unexpected",
            string description = "An unexpected error has occured.")
        {
            return new Error(ErrorType.Unexpected, code, description);
        }

        public static Error Validation(
            string code = "General.Validation",
            string description = "A validation error has occured.")
        {
            return new Error(ErrorType.Validation, code, description);
        }

        public static Error Custom(
            int type,
            string code,
            string description)
        {
            return new Error((ErrorType)type, code, description);
        }
    }
}