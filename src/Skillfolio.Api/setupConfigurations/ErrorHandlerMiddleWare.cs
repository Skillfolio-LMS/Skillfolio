using System.Text.Json;
using FluentValidation;
using Skillfolio.Application.Exceptions;

namespace Skillfolio.Api.setupConfigurations;

public class ErrorHandlerMiddleWare(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        return exception switch
        {
            ValidationException validationException => HandleValidationException(context, validationException),
            CustomException customException => HandleCustomException(context, customException),
            _ => HandleGenericException(context, exception)
        };
    }

    private static Task HandleGenericException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = 500;
        var result = JsonSerializer.Serialize(new { error = "An unexpected error occurred." });
        return context.Response.WriteAsync(result);
    }

    private static Task HandleCustomException(HttpContext context, CustomException customException)
    {
        context.Response.StatusCode = customException.StatusCode;
        var result = JsonSerializer.Serialize(new { error = customException.ErrorMessage });
        return context.Response.WriteAsync(result);
    }

    private static Task HandleValidationException(HttpContext context, ValidationException validationException)
    {
        context.Response.StatusCode = 400;
        var errors = validationException.Errors.Select(err => new
        {
            err.PropertyName,
            err.ErrorMessage
        });
        var result = JsonSerializer.Serialize(new { errors });
        return context.Response.WriteAsync(result);
    }
}
