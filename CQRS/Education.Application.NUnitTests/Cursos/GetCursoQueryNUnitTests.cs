using AutoFixture;
using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTests
    {
        private GetCursoQuery.GetCursoQueryHandler handlerAllCursos = null!;

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

            //2. Emular al MapperConfig

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest.MappingTest());
            });
            var mapper = mapConfig.CreateMapper();


            //3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandler y pasarle como parametro 

            // los objetos dbContext y Mapper. Esta clase es la que tiene el metodo que trae la lista de cursos
            handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(dbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoQueryHandler_ConsultaCursos_ReturnNotNull()
        {
            var request = new GetCursoQuery.GetCursoQueryRequest();
            var resultados = await handlerAllCursos.Handle(request, new System.Threading.CancellationToken());
            Assert.That(resultados, Is.Not.Null);
        }
    }
}
