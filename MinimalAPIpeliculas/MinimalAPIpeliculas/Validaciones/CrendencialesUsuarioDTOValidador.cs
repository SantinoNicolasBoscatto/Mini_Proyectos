using FluentValidation;
using MinimalAPIpeliculas.DTO;

namespace MinimalAPIpeliculas.Validaciones
{
    public class CrendencialesUsuarioDTOValidador : AbstractValidator<CrendencialesUsuariosDTO>
    {
        public CrendencialesUsuarioDTOValidador()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(Utilidades.Utilidades.CampoRequeridoMensaje).MaximumLength(256).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage(Utilidades.Utilidades.CampoRequeridoMensaje).MaximumLength(128);
        }
    }
}
