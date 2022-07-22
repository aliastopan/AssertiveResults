namespace AssertiveResults.Errors
{
    public class Error
    {
        public string Message { get; internal set; }

        public Error()
        {
            Message = "Unspecified error has occurred.";
        }

        public Error(string errorMessage)
        {
            Message = errorMessage;
        }
    }
}