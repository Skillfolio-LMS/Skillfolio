namespace Skillfolio.Application.Exceptions;

public class ObjectNotFoundException : CustomException
{
    public ObjectNotFoundException(string message)
    {
        ErrorMessage = message;
        StatusCode = 404;
    }
}