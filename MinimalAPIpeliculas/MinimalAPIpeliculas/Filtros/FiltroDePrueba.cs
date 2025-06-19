
using AutoMapper;
using MinimalAPIpeliculas.Repositorio;
using System.Linq;

namespace MinimalAPIpeliculas.Filtros
{
    public class FiltroDePrueba : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var result = await next(context);
            var paramIMapper = context.Arguments.OfType<IMapper>().FirstOrDefault();
            var paramIActor = context.Arguments.OfType<IActoresService>().FirstOrDefault();
            return result;
        }
    }
}
