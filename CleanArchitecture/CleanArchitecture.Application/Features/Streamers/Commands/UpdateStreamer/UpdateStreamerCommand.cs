using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommand : IRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("No puede estar el campo vacio")
                        .NotNull().WithMessage("El campo no puede estar vacio")
                        .MaximumLength(50).WithMessage("El Nombre no debe exceder los 50 Caracteres");
        }
    }
}
