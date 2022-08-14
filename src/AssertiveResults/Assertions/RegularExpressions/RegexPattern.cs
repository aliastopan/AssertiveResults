namespace AssertiveResults.Assertions.RegularExpressions
{
    public static class RegexPattern
    {
        public static class Password
        {
            public const string Standard = @"^(?=.*[a-z])(?=.*\d)[a-zA-Z\d]{8,}$";
            public const string Complex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            public const string Maximum = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[~!@#$%^&*\-+=_(){}<>'"":;,.\/\[\]|\\?]).{8,}$";
        }

        public const string LowerCase = "[a-z]+";
        public const string UpperCase = "[A-Z]+";
        public const string Alphameric = "[a-zA-Z0-9]+";
        public const string Alphabet = "[a-zA-Z]+";
        public const string Number = "[0-9]+";
        public const string Symbols = @"[~!@#$%^&*\-+=_(){}<>'"":;,.\/\[\]|\\?]+";
        public const string EmailAddress = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        public static string Length(int min, int max) => string.Concat("^.{", min, ",", max, "}$");
        public static string MinLength(int min) => string.Concat("^.{", min, ",}$");
        public static string MaxLength(int max) => string.Concat("^.{0,", max, "}$");
        public static string Username(int min, int max) => string.Concat("^(?=.{", min, ",", max, "}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
    }
}