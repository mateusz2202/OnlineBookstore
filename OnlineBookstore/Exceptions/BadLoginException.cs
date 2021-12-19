namespace OnlineBookstore.Exceptions
{
    public class BadLoginException : Exception
    {
        public BadLoginException(string? message) : base(message)
        {
        }
    }
}
