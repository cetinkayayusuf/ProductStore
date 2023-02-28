namespace ProductStore.Application.Exceptions;

public class UserRegisterFailedException : Exception
{
    public UserRegisterFailedException() : base("Credentials failed!")
    {
    }

    public UserRegisterFailedException(string? message) : base(message)
    {
    }

    public UserRegisterFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}