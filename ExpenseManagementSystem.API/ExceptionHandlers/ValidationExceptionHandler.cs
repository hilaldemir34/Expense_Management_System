using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.ExceptionHandlers;
public sealed class ValidationExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ValidationExceptionHandler> _logger;

    public ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
     HttpContext httpContext,
     Exception exception,
     CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return true;
        }

        _logger.LogWarning(
            exception, "Validation exception occurred: {Message}", exception.Message);

        var errors = validationException.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray());

        var problemDetails = new ValidationProblemDetails(errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation error",
            Instance = httpContext.Request.Path
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

}
