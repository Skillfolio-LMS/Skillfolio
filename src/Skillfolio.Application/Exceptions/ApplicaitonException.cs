namespace Skillfolio.Application.Exceptions;

public class ApplicationException : Exception
{
    public string ErrorMessage { get; protected set; } = string.Empty;
    public int StatusCode { get; protected set; }
}
