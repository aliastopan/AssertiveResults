namespace AssertiveResults.Assertions.RegularExpressions
{
    public static class Expression
    {
        public static class Password
        {
            public static string Standard()
            {
                return @"^(?=.*[a-z])(?=.*\d)[a-zA-Z\d]{8,}$";
            }

            public static string Complex()
            {
                return @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            }

            public static string Maximum()
            {
                return @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[~!@#$%^&*\-+=_(){}<>'"":;,.\/\[\]|\\?]).{8,}$";
            }
        }

        public const string LowerCase = "[a-z]+";
        public const string UpperCase = "[A-Z]+";
        public const string Alphameric = "[a-zA-Z0-9]+";
        public const string Alphabet = "[a-zA-Z]+";
        public const string Number = "[0-9]+";
        public const string Symbols = @"[~!@#$%^&*\-+=_(){}<>'"":;,.\/\[\]|\\?]+";

        public static string Length(int min, int max)
        {
            return string.Concat("^.{", min, ",", max, "}$");
        }

        public static string MinLength(int min)
        {
            return string.Concat("^.{", min, ",}$");
        }

        public static string MaxLength(int max)
        {
            return string.Concat("^.{0,", max, "}$");
        }

        public static string Username(int min, int max)
        {
            return string.Concat("^(?=.{", min, ",", max, "}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
        }

        public static string Email()
        {
            return @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        }
    }
}