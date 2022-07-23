namespace AssertiveResults.Assertions
{
    public interface IMatch
    {
        IAssertion MinLength(int min);
        IAssertion MaxLength(int max);
        IAssertion Length(int min, int max);
        IAssertion Numbers();
        IAssertion LowerCaseCharacters();
        IAssertion UpperCaseCharacters();
        IAssertion SpecialCharacters();
    }
}