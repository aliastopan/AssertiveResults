namespace AssertiveResults.Assertions
{
    public interface IRegex
    {
        IAssertion NumericCharacters();
        IAssertion LowerCaseCharacters();
        IAssertion UpperCaseCharacters();
        IAssertion SpecialCharacters();
        IAssertion Pattern(string pattern);
    }
}