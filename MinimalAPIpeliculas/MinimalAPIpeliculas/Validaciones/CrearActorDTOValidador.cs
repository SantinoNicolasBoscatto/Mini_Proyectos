using FluentValidation;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Utilidades;

namespace MinimalAPIpeliculas.Validaciones
{
    public class CrearActorDTOValidador : AbstractValidator<CrearActorDTO>
    {
        public CrearActorDTOValidador()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage(Utilidades.Utilidades.CampoRequeridoMensaje);

            var fechaMinima = new DateTime(1900, 1, 1);
            RuleFor(x => x.FechaNacimiento).GreaterThanOrEqualTo(fechaMinima)
                .WithMessage("El Campo {PropertyName} Debe ser posterior a" + fechaMinima.ToString("yyyy-MM-dd"));
        }
    }
}
