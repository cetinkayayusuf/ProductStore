namespace ProductStore.Application.Exceptions;

public class NotOwnedResourceAccessException : Exception
{
    public NotOwnedResourceAccessException() : base("User does not owns the resource!")
    {
    }

    public NotOwnedResourceAccessException(string? message) : base(message)
    {
    }

    public NotOwnedResourceAccessException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}