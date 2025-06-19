
using FluentValidation;
using MinimalAPIpeliculas.DTO;

namespace MinimalAPIpeliculas.Filtros
{
    public class FiltroValidaciones<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validador = context.HttpContext.RequestServices.GetService<IValidator<T>>();
            if (validador == null) return await next(context);

            var elementoValidar = context.Arguments.OfType<T>().FirstOrDefault();
            if (elementoValidar == null) return TypedResults.Problem("No se pudo encontrar la entidad a validar");

            var result = await validador.ValidateAsync(elementoValidar);
            if (!result.IsValid) return TypedResults.ValidationProblem(result.ToDictionary());

            return await next(context);
        }
    }
}
