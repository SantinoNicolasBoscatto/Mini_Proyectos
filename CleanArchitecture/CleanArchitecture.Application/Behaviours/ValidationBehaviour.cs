using ValidationException = CleanArchitecture.Application.Exceptions.ValidationException;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Behaviours
{
    // Behaviour del pipeline, similar a un Middleware
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        // Voy a crear una lista que guarde todas las validaciones de FluentValidator, y la vamos a inyectar por constructor.
        private readonly IEnumerable<IValidator<TRequest>> validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        // TRequest viene a representar la solucitud HTTP del cliente y todos sus datos
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // Creo una lista que recibira todos los resultados de las validaciones, esta ejecuta todas las
                // validaciones de nuestra APP. Estas se ejecutan en el Pipeline-Behaviuor.
                var validationResults = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                // verifico si alguno de esos resultados devuelve un error
                var errors = validationResults.SelectMany(x => x.Errors).Where(x => x != null).ToList();

                // Si tengo errores tirare una excepcion y cortare la ejecucion del Pipeline
                if(errors.Any()) throw new ValidationException(errors);
            }
            return await next();
        }
    }
}
