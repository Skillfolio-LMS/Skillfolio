namespace Skillfolio.Application.Exceptions;

public class CustomException : Exception
{
    public string ErrorMessage { get; protected set; } = string.Empty;
    public int StatusCode { get; protected set; }
}