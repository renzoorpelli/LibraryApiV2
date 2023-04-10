using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace StockService.Middleware;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;

            var problemDetails = new ValidationProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = 400,
                Extensions =
                {
                    ["traceId"] = context.TraceIdentifier
                }
            };

            foreach (var validationFailure in ex.Errors)
            {
                problemDetails.Errors.Add(new KeyValuePair<string, string[]>(
                    validationFailure.PropertyName, new []{validationFailure.ErrorMessage}));
            }

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}