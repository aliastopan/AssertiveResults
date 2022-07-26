namespace AssertiveResults
{
    /// <summary>
    /// Password strength
    /// </summary>
    public enum PasswordStrength
    {
        /// <summary>Contain 1 lowercase letter, 1 number, and be at least 8 characters long</summary>
        Standard,
        /// <summary>Contain 1 lowercase letter, 1 uppercase letter, 1 number, and be at least 8 characters long</summary>
        Complex,
        /// <summary>Contain 1 lowercase letter, 1 uppercase letter, 1 number, 1 special character, and be at least 8 characters long</summary>
        Maximum
    }
}