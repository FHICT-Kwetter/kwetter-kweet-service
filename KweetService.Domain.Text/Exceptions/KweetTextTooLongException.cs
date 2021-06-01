using KweetService.Domain.Text.Exceptions.Base;

namespace KweetService.Domain.Text.Exceptions
{
    public class KweetTextTooLongException : KwetterTextException
    {
        internal KweetTextTooLongException() : base("The kweet content has too many characteres, the limit is 140.")
        {
        }
    }
}