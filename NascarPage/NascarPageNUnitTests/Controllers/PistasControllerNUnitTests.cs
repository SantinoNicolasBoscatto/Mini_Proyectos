using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NascarPage;
using NascarPage.Controllers;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NascarPageNUnitTests.Controllers
{
    [TestFixture]
    public class PistasControllerNUnitTests
    {
        private PistasController pistasController = null!;
        private Mock<IPistaService> pistaServiceMock = null!;
        private Mock<IFilesService> fileServiceMock = null!;
        private Mock<ILogger<AutosController>> loggerMock = null!;
        private List<Pista> Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Pista>().ToList();
            Prueba = list;


            pistaServiceMock = new Mock<IPistaService>();
            pistaServiceMock.Setup(x => x.GetCalendario()).ReturnsAsync(new Calendario { Id = 1, CantidadDeEventos = 36, EventoActual = 1});
            pistaServiceMock.Setup(x => x.GetPistas(true)).ReturnsAsync(list);
            pistaServiceMock.Setup(x => x.GetPistas(false)).ReturnsAsync(list);
            pistaServiceMock.Setup(x => x.GetPistaId(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            pistaServiceMock.Setup(x => x.AgregarPista(It.IsAny<Pista>()));
            pistaServiceMock.Setup(x => x.ModificarPista(It.IsAny<Pista>()));
            pistaServiceMock.Setup(x => x.EliminarPista(It.IsAny<int>())).ReturnsAsync((It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            pistaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(true);


            fileServiceMock = new Mock<IFilesService>();
            fileServiceMock.Setup(x => x.GuardarImagen(It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Editar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Borrar(It.IsAny<string>(), It.IsAny<string>()));

            var loggerMock = new Mock<ILogger<PistasController>>();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            var mapper = mappingConfig.CreateMapper();

            pistasController = new PistasController(pistaServiceMock.Object, fileServiceMock.Object, mapper, loggerMock.Object);
        }

        // GET
        [Test]
        public async Task Get_GetListPistas_ReturnsNotNull()
        {
            var result = await pistasController.Get(true);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaPistaDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
        [Test]
        public async Task GetId_GetPistaporId_ReturnsNotNull()
        {
            var result = await pistasController.GetPorId(Prueba[0].Id);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var entity = (LecturaPistaDTO)status.Value!;
            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.EqualTo(Prueba[0].Id));
        }

        // POST
        [Test]
        public async Task Post_GetStatus201_Returns201()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearPistaDTO { Disputada = true, Distancia = "3", EnElCalendario = true, FotoPrimaria = fileMock.Object, FotoSecundaria = fileMock.Object,
            FotoTerciaria = fileMock.Object, Nombre = "a", Orden = 1, Vueltas = 1};
            var result = await pistasController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(201, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_FotoNull_Returns400()
        {
            var DTO = new CrearPistaDTO
            {
                Disputada = true,
                Distancia = "3",
                EnElCalendario = true,
                FotoPrimaria = null,
                FotoSecundaria = null,
                FotoTerciaria = null,
                Nombre = "a",
                Orden = 1,
                Vueltas = 1
            };
            var result = await pistasController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // PUT
        [Test]
        public async Task Put_GetStatus204NotContent_Return204()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearPistaDTO
            {
                Disputada = true,
                Distancia = "3",
                EnElCalendario = true,
                FotoPrimaria = fileMock.Object,
                FotoSecundaria = fileMock.Object,
                FotoTerciaria = fileMock.Object,
                Nombre = "a",
                Orden = 1,
                Vueltas = 1
            };
            var result = await pistasController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_GetStatus204NotContentFotoNull_Return204()
        {
            var DTO = new CrearPistaDTO
            {
                Disputada = true,
                Distancia = "3",
                EnElCalendario = true,
                FotoPrimaria = null,
                FotoSecundaria = null,
                FotoTerciaria = null,
                Nombre = "a",
                Orden = 1,
                Vueltas = 1
            };
            var result = await pistasController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExiste_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearPistaDTO
            {
                Disputada = true,
                Distancia = "3",
                EnElCalendario = true,
                FotoPrimaria = fileMock.Object,
                FotoSecundaria = fileMock.Object,
                FotoTerciaria = fileMock.Object,
                Nombre = "a",
                Orden = 1,
                Vueltas = 1
            };
            pistaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await pistasController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // DELETE
        [Test]

        public async Task Delete_Get204NotContent_Return204()
        {
            var result = await pistasController.Delete(Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Delete_Get400BadRequest_Return400()
        {
            pistaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await pistasController.Delete(Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
    }
}
