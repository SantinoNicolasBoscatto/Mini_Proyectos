using FluentValidation;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Repositorio;
using MinimalAPIpeliculas.Utilidades;

namespace MinimalAPIpeliculas.Validaciones
{
    public class CrearGeneroDTOValidador : AbstractValidator<CrearGeneroDTO>
    {

        public CrearGeneroDTOValidador(IGeneroService generoService, IHttpContextAccessor httpContext)
        {
            var valorDeRuta = httpContext.HttpContext?.Request.RouteValues["id"];
            var id = 0;
            if(valorDeRuta is string valorString) int.TryParse(valorString, out id);

            RuleFor(x => x.Nombre).NotEmpty().WithMessage(Utilidades.Utilidades.CampoRequeridoMensaje)
                       .MaximumLength(75).WithMessage("El Campo {PropertyName} tiene una logitud maxima de {MaxLength} caracteres")
                       .Must(Utilidades.Utilidades.PrimeraLetraEnMayuscula).WithMessage("El Campo {PropertyName} debe comenzar con mayuscula")
                       .MustAsync(async (nombre, _) =>
                       {
                           var existe = await generoService.ExisteGeneroNombre(id, nombre);
                           return !existe;
                       }).WithMessage(g => $"Ya existe un genero con el nombre: {g.Nombre}");
            
        }

        
    }
}
