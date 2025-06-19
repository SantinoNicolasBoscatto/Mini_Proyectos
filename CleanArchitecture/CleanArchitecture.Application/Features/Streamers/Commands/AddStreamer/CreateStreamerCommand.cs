using CleanArchitecture.Domain;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.AddStreamer
{
    public class CreateStreamerCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    // AbstractValidator viene de FluentValidation
    public class AddStreamerCommandValidator : AbstractValidator<CreateStreamerCommand> // Indico la clase a validar
    {
        public AddStreamerCommandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("No puede estar el campo vacio")
                        .NotNull().WithMessage("El campo no puede estar vacio")
                        .MaximumLength(50).WithMessage("El Nombre no debe exceder los 50 Caracteres");
        }
    }
}
