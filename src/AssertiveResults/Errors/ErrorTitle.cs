namespace AssertiveResults.Errors
{
    internal static class ErrorTitle
    {
        internal const string Failure = "General.Failure";
        internal const string Conflict = "General.Conflict";
        internal const string NotFound = "General.NotFound";
        internal const string Unexpected = "General.Unexpected";
        internal const string Validation = "General.Validation";
        internal const string Authentication = "General.Authentication";
        internal const string Authorization = "General.Authorization";

        internal static class Assertion
        {
            internal const string Boolean = "Boolean.Assertion";
            internal const string ObjectReference = "ObjectReference.Assertion";
            internal const string Value = "Value.Assertion";
            internal const string Collection = "Collection.Assertion";
            internal const string RegularExpression = "RegularExpression.Validation";
            internal const string UsernameStandard = "Username.Validation";
            internal const string PasswordStrength = "PasswordStrength.Validation";
            internal const string EmailAddressFormat = "EmailAddress.Validation";
        }
    }
}