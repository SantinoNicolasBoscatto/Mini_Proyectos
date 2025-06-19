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
    public class NoticiasControllerNUnitTests
    {
        private NoticiasController noticiasController = null!;
        private Mock<INoticiaService> noticiaServiceMock = null!;
        private Mock<IFilesService> fileServiceMock = null!;
        private Mock<ILogger<NoticiasController>> loggerMock = null!;
        private List<Noticia> Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Noticia>().ToList();
            Prueba = list;

            noticiaServiceMock = new Mock<INoticiaService>();
            noticiaServiceMock.Setup(x => x.GetNoticias()).ReturnsAsync(list);
            noticiaServiceMock.Setup(x => x.GetNoticiaId(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            noticiaServiceMock.Setup(x => x.AgregarNoticia(It.IsAny<Noticia>()));
            noticiaServiceMock.Setup(x => x.ModificarNoticia(It.IsAny<Noticia>()));
            noticiaServiceMock.Setup(x => x.EliminarNoticia(It.IsAny<int>())).ReturnsAsync(It.IsAny<string>());
            noticiaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(true);

            fileServiceMock = new Mock<IFilesService>();
            fileServiceMock.Setup(x => x.GuardarImagen(It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Editar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Borrar(It.IsAny<string>(), It.IsAny<string>()));

            var loggerMock = new Mock<ILogger<NoticiasController>>();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            var mapper = mappingConfig.CreateMapper();

            noticiasController = new NoticiasController(noticiaServiceMock.Object, fileServiceMock.Object, mapper, loggerMock.Object);
        }

        // GET
        [Test]
        public async Task Get_GetListNoticias_ReturnsNotNull()
        {
            var result = await noticiasController.Get();
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaNoticiaDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
        [Test]
        public async Task GetId_GetNoticiaporId_ReturnsNotNull()
        {
            var result = await noticiasController.GetPorId(Prueba[0].Id);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var entity = (LecturaNoticiaDTO)status.Value!;
            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.EqualTo(Prueba[0].Id));
        }

        // POST
        [Test]
        public async Task Post_GetStatus201_Returns201()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearNoticiaDTO { Detalles = "", Titulo = "NotNull", Foto = fileMock.Object };
            var result = await noticiasController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(201, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_FotoNull_Returns400()
        {
            var DTO = new CrearNoticiaDTO { Detalles = "", Titulo = "", Foto = null };
            var result = await noticiasController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // PUT
        [Test]
        public async Task Put_GetStatus204NotContent_Return204()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearNoticiaDTO { Detalles = "", Titulo = "", Foto = fileMock.Object };
            var result = await noticiasController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_GetStatus204NotContentFotoNull_Return204()
        {
            var DTO = new CrearNoticiaDTO { Detalles = "", Titulo = "", Foto = null };
            var result = await noticiasController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExiste_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearNoticiaDTO { Detalles = "", Titulo = "", Foto = fileMock.Object };
            noticiaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await noticiasController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // DELETE
        [Test]
        public async Task Delete_Get204NotContent_Return204()
        {
            var result = await noticiasController.Delete(Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Delete_Get400BadRequest_Return400()
        {
            noticiaServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await noticiasController.Delete(Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
    }
}
