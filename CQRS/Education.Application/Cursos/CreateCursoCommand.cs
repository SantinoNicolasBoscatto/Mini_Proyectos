using AutoMapper;
using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    // Dentro de esta clase iran todos los CQRS de escritura
    public class CreateCursoCommand
    {
        // Aca definire las propiedades que quiero cargar, defino los parametros que debera cargar el cliente para crear un objeto
        public class CreateCursoCommandRequest : IRequest
        {
            public string Titulo { get; set; } = null!;
            public string Descripcion { get; set; } = null!;
            public DateTime FechaPublicacion { get; set; }
            public decimal Precio { get; set; }
        }

        // Esta es la clase que definira la logica de insercion a BD
        public class CreateCursoCommandHandler : IRequestHandler<CreateCursoCommandRequest>
        {
            private readonly EducationDbContext _context;
            public CreateCursoCommandHandler(EducationDbContext context)
            {
                _context = context;
            }

            public async Task Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
            {
                var curso = new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion,
                    FechaCreacion = DateTime.UtcNow,
                    Precio = request.Precio
                };
                _context.Add(curso);
                await _context.SaveChangesAsync();
            }
        }

        public class CreateCursoCommandRequestValidation : AbstractValidator<CreateCursoCommandRequest> // Esta clase viene de FluentValidator
        {
            // Con FluentValidator puedo definir validaciones en un constructor
            public CreateCursoCommandRequestValidation() 
            {
                RuleFor(x => x.Descripcion);
                RuleFor(x => x.Titulo);
            }
        }
    }
}
