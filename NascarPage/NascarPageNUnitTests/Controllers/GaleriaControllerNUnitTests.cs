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
    public class GaleriaControllerNUnitTests
    {
        private GaleriaController galeriaController = null!;
        private Mock<IGaleriaService> galeriaServiceMock = null!;
        private Mock<IFilesService> fileServiceMock = null!;
        private Mock<ILogger<AutosController>> loggerMock = null!;
        private List<Galeria> Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaAutos = fixture.CreateMany<Galeria>().ToList();
            Prueba = listaAutos;


            galeriaServiceMock = new Mock<IGaleriaService>();
            galeriaServiceMock.Setup(x => x.GetFotos(It.IsAny<PaginacionDTO>())).ReturnsAsync(listaAutos);
            galeriaServiceMock.Setup(x => x.GetFotosPorId(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            galeriaServiceMock.Setup(x => x.GetFotosPorRonda(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            galeriaServiceMock.Setup(x => x.AgregarGaleria(It.IsAny<Galeria>()));
            galeriaServiceMock.Setup(x => x.ModificarGaleria(It.IsAny<Galeria>()));
            galeriaServiceMock.Setup(x => x.Eliminar(It.IsAny<int>())).ReturnsAsync(It.IsAny<(string?, string?, string?)>());
            galeriaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(true);

            fileServiceMock = new Mock<IFilesService>();
            fileServiceMock.Setup(x => x.GuardarImagen(It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Editar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Borrar(It.IsAny<string>(), It.IsAny<string>()));

            var loggerMock = new Mock<ILogger<GaleriaController>>();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            var mapper = mappingConfig.CreateMapper();

            galeriaController = new GaleriaController(fileServiceMock.Object, mapper, galeriaServiceMock.Object, loggerMock.Object);
        }

        // GET
        [Test]
        public async Task Get_GetListAutos_ReturnsNotNull()
        {
            var result = await galeriaController.Get(new PaginacionDTO {  Pagina = 1, RecordsPorPagina = 3 });
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaGaleriaDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
        [Test]
        public async Task GetId_GetAutoporId_ReturnsNotNull()
        {
            var result = await galeriaController.GetPorId(Prueba[0].Id);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var entity = (LecturaGaleriaDTO)status.Value!;
            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.EqualTo(Prueba[0].Id));
        }

        // POST
        [Test]
        public async Task Post_GetStatus201_Returns201()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearGaleriaDTO { FotoUno = fileMock.Object, FotoDos = fileMock.Object, FotoTres = fileMock.Object, Ronda = 5 };
            var result = await galeriaController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(201, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_FotoNull_Returns400()
        {
            var DTO = new CrearGaleriaDTO { FotoUno = null, FotoDos = null, FotoTres = null, Ronda = 5 };
            var result = await galeriaController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // PUT
        [Test]
        public async Task Put_GetStatus204NotContent_Return204()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearGaleriaDTO { FotoUno = fileMock.Object, FotoDos = fileMock.Object, FotoTres = fileMock.Object, Ronda = 5 };
            var result = await galeriaController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_GetStatus204NotContentFotoNull_Return204()
        {
            var DTO = new CrearGaleriaDTO { FotoUno = null, FotoDos = null, FotoTres = null, Ronda = 5 };
            var result = await galeriaController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExiste_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearGaleriaDTO { FotoUno = fileMock.Object, FotoDos = fileMock.Object, FotoTres = fileMock.Object, Ronda = 5 };
            galeriaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await galeriaController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // DELETE
        [Test]
        public async Task Delete_Get204NotContent_Return204()
        {
            var result = await galeriaController.Delete(Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }

        [Test]
        public async Task Delete_Get400BadRequest_Return400()
        {
            galeriaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await galeriaController.Delete(Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
    }
}
