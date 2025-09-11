namespace Skillfolio.Application.Exceptions;

public class ObjectNotFoundException : ApplicationException
{
    public ObjectNotFoundException(string message)
    {
        ErrorMessage = message;
        StatusCode = 404;
    }
}