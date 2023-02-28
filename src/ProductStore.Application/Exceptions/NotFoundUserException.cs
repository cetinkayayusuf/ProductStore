namespace ProductStore.Application.Exceptions;

public class NotFoundUserException : Exception
{
    public NotFoundUserException() : base("Email or password wrong!")
    {
    }

    public NotFoundUserException(string? message) : base(message)
    {
    }

    public NotFoundUserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}