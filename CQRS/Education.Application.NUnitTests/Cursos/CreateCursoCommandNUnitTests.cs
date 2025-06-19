using AutoFixture;
using AutoMapper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class CreateCursoCommandNUnitTests
    {
        private CreateCursoCommand.CreateCursoCommandHandler handlerCreateCursos = null!;
        [SetUp]
        public void Setup()
        {
            // 1. Emular el DbContext que representa la instancia de EF

            // Este objeto sera el encargado de generar data de prueba
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();
            // Creo un curso con su Id vacio
            cursoRecords.Add(fixture.Build<Curso>().With(x => x.CursoId, Guid.Empty).Create());

            // Crearemos una BD en memoria
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                         .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}").Options;
            var dbContextFake = new EducationDbContext(options);
            // Cargo la data de esta BD en memoria
            dbContextFake.Cursos.AddRange(cursoRecords);
            dbContextFake.SaveChanges();

            //2. Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandler y pasarle como parametro 

            // los objetos dbContext y Mapper. Esta clase es la que tiene el metodo que trae la lista de cursos
            handlerCreateCursos = new CreateCursoCommand.CreateCursoCommandHandler(dbContextFake);
        }

        [Test]
        public async Task CreateCursoCommand_InputCursoRequest_ReturnsTrue()
        {
            CreateCursoCommand.CreateCursoCommandRequest request = new()
            {
                Descripcion = "",
                FechaPublicacion = DateTime.Now,
                Precio = 335,
                Titulo = "Algo"
            };
            await handlerCreateCursos.Handle(request, new System.Threading.CancellationToken());
        }
    }
}
