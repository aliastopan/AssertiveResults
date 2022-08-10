using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.Exception
{
    internal class Exception : IException
    {
        private readonly Context _context;

        internal Exception(Context assertion)
        {
            _context = assertion;
        }

        public IException Catch(Error error)
        {
            _context.Errors.Add(error);
            return this;
        }
    }
}