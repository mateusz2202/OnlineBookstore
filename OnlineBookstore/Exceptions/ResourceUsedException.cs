namespace OnlineBookstore.Exceptions
{
    public class ResourceUsedException : Exception
    {
        public ResourceUsedException(string? message) : base(message)
        {
        }
    }
}
