namespace AssertiveResults.Assertions
{
    public interface IMatch
    {
        IAssertion MinLength();
        IAssertion MaxLength();
        IAssertion Length(int min, int max);
        IAssertion Numbers();
        IAssertion LowerCaseCharacters();
        IAssertion UpperCaseCharacters();
        IAssertion SpecialCharacters();
    }
}