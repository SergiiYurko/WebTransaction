using System;

namespace WebTransaction.Handlers.Helpers
{
    public class ValidationException: Exception
    {
        public ValidationException(string message): base(message)
        {
        }
    }
}