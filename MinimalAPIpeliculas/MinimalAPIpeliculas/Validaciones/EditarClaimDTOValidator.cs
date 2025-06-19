using FluentValidation;
using MinimalAPIpeliculas.DTO;

namespace MinimalAPIpeliculas.Validaciones
{
    public class EditarClaimDTOValidator : AbstractValidator<EditarClaimDTO>
    {
        public EditarClaimDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
        }
    }
}
