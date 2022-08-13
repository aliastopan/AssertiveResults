namespace AssertiveResults.Errors
{
    internal static class ErrorDescription
    {
        // GENERAL
        internal const string Failure = "A failure has occurred.";
        internal const string Conflict = "A conflict error has occurred.";
        internal const string NotFound = "A 'Not Found' error has occurred.";
        internal const string Unexpected = "An unexpected error has occurred.";
        internal const string Validation = "A validation error has occurred.";

        // VALUE CHECK
        internal const string ValueCheck = "A value check error has occurred.";
        internal const string UnsatisfiedCondition = "Assertion not satisfied the specified condition.";
        internal const string SatisfiedIllegalCondition = "Assertion satisfied the specified illegal condition.";
        internal const string ReferenceIsNull = "Object reference must not be null.";
        internal const string ReferenceIsNotNull = "Object reference must be null.";
        internal const string ReferencesNotAreTheSame = "Object references must be the same.";
        internal const string ReferencesAreTheSame = "Object references must not be the same.";
        internal const string CollectionIsEmpty = "Collection must not be empty.";
        internal const string CollectionIsNotEmpty = "Collection must be empty.";
        internal const string ObjectsAreNotEqual = "Objects must be equal.";
        internal const string ObjectsAreEqual = "Objects must not be equal.";
        internal const string ObjectsAreNotStrictlyEqual = "Objects must have identical value(s).";
        internal const string ObjectsAreStrictlyEqual = "Objects must not have identical value(s).";

        // REGULAR EXPRESSION
        internal const string StringNotMatchesRegularExpression = "String doesn't match with the given {0} expression.";
        internal const string StringMatchesIllegalRegularExpression = "String match with the given illegal {0} expression.";
        internal const string StringInvalidLength = "String must be between {0} and {1} characters.";
        internal const string StringTooShort = "String must be least {0} characters.";
        internal const string StringTooLong = "String cannot be more than {0} characters.";
        internal const string StringMissingLowerCase = "String must contains at least 1 lower-case character.";
        internal const string StringMissingUpperCase = "String must contains at least 1 upper-case character.";
        internal const string StringMissingAlphabet = "String must contains at least 1 alphabet.";
        internal const string StringMissingAlphameric = "String must contains at least 1 of both alphabet and number.";
        internal const string StringMissingNumber = "String must contain at least 1 number.";
        internal const string StringMissingSpecialCharacter = "String must contains at least 1 special character.";
        internal const string InvalidUsernameFormat = "Invalid username format.";
        internal const string InvalidEmailAddressFormat = "Invalid email address format.";
        internal const string WeakPasswordStandard = "Password must contain 1 lowercase letter, 1 number, and be at least 8 characters long.";
        internal const string WeakPasswordComplex = "Password must contain 1 lowercase letter, 1 uppercase letter, 1 number, 1 special character, and be at least 8 characters long.";
        internal const string WeakPasswordMaximum = "Password must contain 1 lowercase letter, 1 uppercase letter, 1 number, and be at least 8 characters long.";
    }
}