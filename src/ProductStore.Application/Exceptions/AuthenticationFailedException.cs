namespace ProductStore.Application.Exceptions;

public class AuthenticationFailedException : Exception
{
    public AuthenticationFailedException() : base("Credentials failed!")
    {
    }

    public AuthenticationFailedException(string? message) : base(message)
    {
    }

    public AuthenticationFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}