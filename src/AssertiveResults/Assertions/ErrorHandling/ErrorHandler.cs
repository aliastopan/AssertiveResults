using AssertiveResults.Errors;

namespace AssertiveResults.Assertions.ErrorHandling
{
    internal sealed class ErrorHandler : IErrorHandler
    {
        private readonly Context _context;

        internal ErrorHandler(Context context)
        {
            _context = context;
        }

        public void Catch(Error error)
        {
            _context.Errors.Add(error);
        }
    }
}