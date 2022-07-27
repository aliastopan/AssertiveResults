using AssertiveResults.Assertions;

namespace AssertiveResults.Errors
{
    internal static class ErrorHandler
    {
        internal static void WithErrorDefault(Assertation assertation, ErrorType errorType, string inputName, string errorCode)
        {
            if(!assertation.Failed)
                return;

            var error = assertation.Errors[assertation.Errors.Count - 1];
            var code = error.Code;
            var description = error.Description;

            inputName.PreventNullOrEmptyOrWhiteSpace(@default: assertation.InputName);
            inputName.PreventNullOrWhiteSpace(@default: string.Empty);

            if(errorCode == string.Empty && inputName != assertation.InputName)
            {
                code = code.Replace(assertation.ErrorCode, inputName);
                description = description.Replace(assertation.InputName, inputName);
                System.Console.WriteLine(description);
            }

            if(errorCode != string.Empty && inputName != string.Empty)
            {
                code = errorCode;
                description = description.Replace(assertation.InputName, inputName);
            }

            error = ErrorTypeHandler(errorType, code, description);
            assertation.Errors.RemoveAt(assertation.Errors.Count - 1);
            assertation.Errors.Add(error);
        }

        internal static void WithError(Assertation assertation, Error error)
        {
            if(assertation.Failed)
            {
                assertation.Errors.RemoveAt(assertation.Errors.Count - 1);
                assertation.Errors.Add(error);
            }
        }

        internal static Error ErrorTypeHandler(ErrorType errorType, string errorCode, string errorDescription)
        {
            switch(errorType)
            {
                case ErrorType.Conflict:
                    return Error.Conflict(errorCode, errorDescription);
                case ErrorType.NotFound:
                    return Error.NotFound(errorCode, errorDescription);
                case ErrorType.Unexpected:
                    return Error.Unexpected(errorCode, errorDescription);
                case ErrorType.Validation:
                    return Error.Validation(errorCode, errorDescription);
                default:
                    return Error.Failure(errorCode, errorDescription);
            }
        }

        private static string PreventNullOrEmptyOrWhiteSpace(this string input, string @default)
        {
            if(string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                input = @default;

            return input;
        }

        private static string PreventNullOrWhiteSpace(this string input, string @default)
        {
            if(string.IsNullOrWhiteSpace(input))
                input = @default;

            return input;
        }
    }
}