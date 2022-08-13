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

        internal static Error ValueCheck(
            string code = ErrorCode.Assertion.Value,
            string description = ErrorDescription.ValueCheck)
        {
            return new Error(ErrorType.Failure, code, description);
        }

        public static Error Failure(
            string code = ErrorCode.Failure,
            string description = ErrorDescription.Failure)
        {
            return new Error(ErrorType.Failure, code, description);
        }

        public static Error Conflict(
            string code = ErrorCode.Conflict,
            string description = ErrorDescription.Conflict)
        {
            return new Error(ErrorType.Conflict, code, description);
        }

        public static Error NotFound(
            string code = ErrorCode.NotFound,
            string description = ErrorDescription.NotFound)
        {
            return new Error(ErrorType.NotFound, code, description);
        }

        public static Error Unexpected(
            string code = ErrorCode.Unexpected,
            string description = ErrorDescription.Unexpected)
        {
            return new Error(ErrorType.Unexpected, code, description);
        }

        public static Error Validation(
            string code = ErrorCode.Validation,
            string description = ErrorDescription.Validation)
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