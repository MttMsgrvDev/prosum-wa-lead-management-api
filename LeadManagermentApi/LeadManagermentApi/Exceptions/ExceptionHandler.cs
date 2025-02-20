using FluentValidation;
using LeadManagermentApi.Exceptions.Http;
using LeadManagermentApi.Exceptions.Validation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;

namespace LeadManagermentApi.Exceptions;

public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ProblemDetails problemDetails;
        if (exception is ValidationException validationException)
        {
            problemDetails = GetProblemDetails(httpContext, validationException, cancellationToken);
        }
        else if (exception is HttpException httpException)
        {
            problemDetails = GetProblemDetails(httpContext, httpException, cancellationToken);
        }
        else
        {
            logger.LogError(exception, "Exception occured handling request to path {0}", httpContext.Request.Path);
            problemDetails = GetProblemDetails(httpContext, exception, cancellationToken);
        }

        httpContext.Response.StatusCode = problemDetails?.Status ?? StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);

        return true;
    }

    private ProblemDetails GetProblemDetails(HttpContext context, ValidationException exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Instance = context.Request.Path,
            Title = "one or more validation errors occurred.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        var validationErrors = exception.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage));

        problemDetails.Extensions.Add("errors", validationErrors);

        return problemDetails;
    }

    private ProblemDetails GetProblemDetails(HttpContext context, HttpException exception, CancellationToken cancellationToken)
    {
        return new ProblemDetails
        {
            Status = exception.StatusCode,
            Instance = context.Request.Path,
            Title = exception.ErrorTitle,
            Detail = exception.Message
        };
    }

    private ProblemDetails GetProblemDetails(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        return new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Instance = context.Request.Path,
            Title = "Internal server error.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };
    }
}