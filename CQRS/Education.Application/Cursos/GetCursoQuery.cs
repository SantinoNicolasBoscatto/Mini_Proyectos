using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    // Dentro de esta clase iran todos los CQRS de lectura
    public class GetCursoQuery
    {
        // Esta clase representa los parametros que envia el cliente, en esta clase armaremos el query
        // de la consulta. En este caso no requerimos que el cliente nos pasa ningun parametro
        // List<Curso> es un parametro de salida
        public class GetCursoQueryRequest : IRequest<List<CursoDTO>> // IRequest proviene del paquete MediatR
        {

        }

        //  Esta clase clase Handler es la clase que se encarga de implementar la logica para pasarle el Query a la BD y que me retorne la data.
        //  GetCursoQueryRequest sera un parametro de entrada y List<CursoDTO> sera un parametro de salida.
        //  Este seria un CQRS de lectura.
        public class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, List<CursoDTO>>
        {
            private readonly EducationDbContext dbContext;
            private readonly IMapper mapper;

            public GetCursoQueryHandler(EducationDbContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }

            // Esta funcion definira la logica con la BD
            public async Task<List<CursoDTO>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
            {
                var curso = await dbContext.Cursos.ToListAsync();
                var dtos = mapper.Map<List<CursoDTO>>(curso);
                return dtos;
            }
        }
    }
}
