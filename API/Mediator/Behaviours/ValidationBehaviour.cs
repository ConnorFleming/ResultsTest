using API.Results.Errors;
using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace API.Mediator.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> where TResponse : ResultBase, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
            {
                var result = new TResponse();

                foreach (var validationFailure in failures)
                {
                    result.Reasons.Add(new ValidationError(validationFailure.ErrorCode, validationFailure.ErrorMessage, validationFailure.PropertyName));
                }

                return result;
            }
        }

        return await next();
    }
}