using System;

namespace KweetService.Domain.Text.Exceptions.Base
{
    public class KwetterTextException : Exception
    {
        internal KwetterTextException(string message) : base(message)
        {
        }
    }
}