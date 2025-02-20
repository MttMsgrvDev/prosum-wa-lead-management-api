using FluentValidation;
using MediatR;

namespace LeadManagermentApi.Behavoirs;

/// <summary>
/// Behavoir middleware for the mediator that runs validation logic.
/// </summary>
/// <typeparam name="TRequest">The type of request to be validated.</typeparam>
/// <typeparam name="TResponse">The type of response for the request.</typeparam>
/// <remarks>
/// Creates a new instance of 
/// </remarks>
/// <param name="validators">The validators to run against a request of type TRequest.</param>
public class ValidationBehavoir<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{

    /// <summary>
    /// Validates the request and executes the next step in the pipeline if validation passes.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <param name="next">The next handler in the pipeline.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>The response to the request.</returns>
    /// <exception cref="FluentValidation.ValidationException">If validation fails, contains information about the failed validation failure(s).</exception>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next().ConfigureAwait(false);
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            validators.Select(v =>
                v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

        var failures = validationResults
            .Where(r => r.Errors.Count > 0)
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Count > 0)
        {
            throw new FluentValidation.ValidationException(failures);
        }

        return await next().ConfigureAwait(false);
    }
}