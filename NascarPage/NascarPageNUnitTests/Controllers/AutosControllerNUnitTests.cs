using AutoFixture;
using AutoMapper;
using Castle.Core.Logging;
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
    public class AutosControllerNUnitTests
    {
        private AutosController autosController = null!;
        private Mock<IAutoService> autoServiceMock = null!;
        private Mock<IFilesService> fileServiceMock = null!;
        private Mock<ILogger<AutosController>> loggerMock = null!;
        private List<Auto> Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Auto>().ToList();
            Prueba = list;


            autoServiceMock = new Mock<IAutoService>();
            autoServiceMock.Setup(x => x.GetAutos()).ReturnsAsync(list);
            autoServiceMock.Setup(x => x.GetAutoId(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            autoServiceMock.Setup(x => x.AgregarAuto(It.IsAny<Auto>()));
            autoServiceMock.Setup(x => x.ModificarAuto(It.IsAny<Auto>()));
            autoServiceMock.Setup(x => x.EliminarAuto(It.IsAny<int>())).ReturnsAsync(It.IsAny<string>());
            autoServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(true);
            autoServiceMock.Setup(x => x.ExistePiloto(It.IsAny<int>())).ReturnsAsync(true);
            autoServiceMock.Setup(x => x.ExisteMarca(It.IsAny<int>())).ReturnsAsync(true);

            fileServiceMock = new Mock<IFilesService>();
            fileServiceMock.Setup(x => x.GuardarImagen(It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Editar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Borrar(It.IsAny<string>(), It.IsAny<string>()));

            var loggerMock = new Mock<ILogger<AutosController>>();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            var mapper = mappingConfig.CreateMapper();

            autosController = new AutosController(autoServiceMock.Object, fileServiceMock.Object, mapper, loggerMock.Object);
        }

        // GET
        [Test]
        public async Task Get_GetListAutos_ReturnsNotNull()
        {
            var result = await autosController.Get();
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaAutoDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
        [Test]
        public async Task GetId_GetAutoporId_ReturnsNotNull()
        {
            var result = await autosController.GetPorId(Prueba[0].Id);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var entity = (LecturaAutoDTO)status.Value!;
            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.EqualTo(Prueba[0].Id));
        }

        // POST
        [Test]
        public async Task Post_GetStatus201_Returns201()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = fileMock.Object };
            var result = await autosController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(201, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_FotoNull_Returns400()
        {
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = null };
            var result = await autosController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_PilotoInexistente_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = fileMock.Object };
            autoServiceMock.Setup(x => x.ExistePiloto(It.IsAny<int>())).ReturnsAsync(false);
            var result = await autosController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_MarcaInexistente_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = fileMock.Object };
            autoServiceMock.Setup(x => x.ExisteMarca(It.IsAny<int>())).ReturnsAsync(false);
            var result = await autosController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }


        // PUT
        [Test]
        public async Task Put_GetStatus204NotContent_Return204()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = fileMock.Object };
            var result = await autosController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExiste_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = fileMock.Object };
            autoServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await autosController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExistePiloto_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = fileMock.Object };
            autoServiceMock.Setup(x => x.ExistePiloto(It.IsAny<int>())).ReturnsAsync(false);
            var result = await autosController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExisteMarca_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = fileMock.Object };
            autoServiceMock.Setup(x => x.ExisteMarca(It.IsAny<int>())).ReturnsAsync(false);
            var result = await autosController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_GetStatus204NotContentFotoNull_Return204()
        {
            var DTO = new CrearAutoDTO { MarcaId = Prueba[0].MarcaId, PilotoId = Prueba[0].PilotoId, Foto = null };
            var result = await autosController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }

        // DELETE
        [Test]
        public async Task Delete_Get204NotContent_Return204()
        {
            var result = await autosController.Delete(Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }

        [Test]
        public async Task Delete_Get400BadRequest_Return400()
        {
            autoServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await autosController.Delete(Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
    }
}
