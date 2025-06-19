using Clean_Architecture.Mappers.DTOs.Request;
using FluentValidation;

namespace Clean_Architecture.API.Validators
{
    public class BeerValidator : AbstractValidator<BeerResquestDTO>
    {
        public BeerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El Campo no puede estar vacio").NotNull()
                                .MaximumLength(50).WithMessage("Maximo de 50 Caracteres");                           
        }
    }
}
