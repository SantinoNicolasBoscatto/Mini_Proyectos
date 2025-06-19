using FluentValidation;
using MediatR;
using Pacagroup.Trade.Application.UsesCases.Commons.Exceptions;

namespace Pacagroup.Trade.Application.UsesCases.Commons.Behaviors
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        // Esta variable almacenara todas las reglas de validacion que no se estan cumpliendo.
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // Recupero las validaciones incumplidas y luego recupero sus errores
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any()) throw new ValidationExceptionCustom(failures);
            }
            return await next();
        }
    }
}
