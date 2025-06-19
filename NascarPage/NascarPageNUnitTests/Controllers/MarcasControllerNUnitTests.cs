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
    public class MarcasControllerNUnitTests
    {
        private MarcasController marcasController = null!;
        private Mock<IMarcaService> marcasServiceMock = null!;
        private Mock<IFilesService> fileServiceMock = null!;
        private Mock<ILogger<MarcasController>> loggerMock = null!;
        private List<Marca> Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Marca>().ToList();
            Prueba = list;


            marcasServiceMock = new Mock<IMarcaService>();
            marcasServiceMock.Setup(x => x.GetMarcas()).ReturnsAsync(list);
            marcasServiceMock.Setup(x => x.GetMarcaPorId(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            marcasServiceMock.Setup(x => x.AgregarMarca(It.IsAny<Marca>()));
            marcasServiceMock.Setup(x => x.ActulizarMarca(It.IsAny<Marca>()));
            marcasServiceMock.Setup(x => x.EliminarMarca(It.IsAny<int>())).ReturnsAsync((It.IsAny<string>(), new List<string>()));
            marcasServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(true);

            fileServiceMock = new Mock<IFilesService>();
            fileServiceMock.Setup(x => x.GuardarImagen(It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Editar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Borrar(It.IsAny<string>(), It.IsAny<string>()));

            var loggerMock = new Mock<ILogger<MarcasController>>();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            var mapper = mappingConfig.CreateMapper();

            marcasController = new MarcasController(marcasServiceMock.Object, fileServiceMock.Object, mapper, loggerMock.Object);
        }

        // GET
        [Test]
        public async Task Get_GetListMarcas_ReturnsNotNull()
        {
            var result = await marcasController.Get();
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaMarcaDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
        [Test]
        public async Task GetId_GetMarcaporId_ReturnsNotNull()
        {
            var result = await marcasController.GetPorId(Prueba[0].Id);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var entity = (LecturaMarcaDTO)status.Value!;
            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.EqualTo(Prueba[0].Id));
        }

        // POST
        [Test]
        public async Task Post_GetStatus201_Returns201()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearMarcaDTO { Nombre = "Prueba[0].MarcaId", Foto = fileMock.Object};
            var result = await marcasController.Post(DTO);
            var status = (ObjectResult)result;
            Assert.That(201, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_FotoNull_Returns400()
        {
            var DTO = new CrearMarcaDTO { Nombre = "Prueba[0].MarcaId", Foto = null };
            var result = await marcasController.Post(DTO);
            var status = (ObjectResult)result;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // PUT
        [Test]
        public async Task Put_GetStatus204NotContent_Return204()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearMarcaDTO { Nombre = "Prueba[0].MarcaId", Foto = fileMock.Object };
            var result = await marcasController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_GetStatus204NotContentFotoNull_Return204()
        {
            var DTO = new CrearMarcaDTO { Nombre = "Prueba[0].MarcaId", Foto = null };
            var result = await marcasController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExiste_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearMarcaDTO { Nombre = "Prueba[0].MarcaId", Foto = fileMock.Object };
            marcasServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await marcasController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // DELETE
        [Test]

        public async Task Delete_Get204NotContent_Return204()
        {
            var result = await marcasController.Delete(Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }

        public async Task Delete_Get400BadRequest_Return400()
        {
            marcasServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await marcasController.Delete(Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
    }
}
