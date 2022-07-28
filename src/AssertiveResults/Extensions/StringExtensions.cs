namespace AssertiveResults.Extensions
{
    internal static class StringExtensions
    {
        internal static string PreventNullOrEmptyOrWhiteSpace(this string input, string @default)
        {
            if(string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                input = @default;

            return input;
        }

        internal static string PreventNullOrWhiteSpace(this string input, string @default)
        {
            if(string.IsNullOrWhiteSpace(input))
                input = @default;

            return input;
        }
    }
}