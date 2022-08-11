using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.ErrorHandling
{
    internal sealed class ErrorHandler : IErrorHandler
    {
        private readonly Context _context;

        internal ErrorHandler(Context assertion)
        {
            _context = assertion;
        }

        public void Catch(Error error)
        {
            _context.Errors.Add(error);
        }
    }
}