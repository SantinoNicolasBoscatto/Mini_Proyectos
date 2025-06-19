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
    public class CampeonesControllerNUnitTests
    {
        private CampeonesController campeonesController = null!;
        private Mock<ICampeonService> campeonServiceMock = null!;
        private Mock<IFilesService> fileServiceMock = null!;
        private Mock<ILogger<CampeonesController>> loggerMock = null!;
        private List<Campeon> Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listCampeones = fixture.CreateMany<Campeon>().ToList();
            Prueba = listCampeones;


            campeonServiceMock = new Mock<ICampeonService>();
            campeonServiceMock.Setup(x => x.GetCampeones(It.IsAny<PaginacionDTO>())).ReturnsAsync(listCampeones);
            campeonServiceMock.Setup(x => x.GetCampeonId(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            campeonServiceMock.Setup(x => x.GetCampeonYear(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            campeonServiceMock.Setup(x => x.AgregarCampeon(It.IsAny<Campeon>()));
            campeonServiceMock.Setup(x => x.ModificarCampeon(It.IsAny<Campeon>()));
            campeonServiceMock.Setup(x => x.EliminarCampeon(It.IsAny<int>())).ReturnsAsync(It.IsAny<string>());
            campeonServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(true);
            campeonServiceMock.Setup(x => x.ExistePiloto(It.IsAny<int>())).ReturnsAsync(true);
            campeonServiceMock.Setup(x => x.EsCampeon(It.IsAny<int>())).ReturnsAsync(true);


            fileServiceMock = new Mock<IFilesService>();
            fileServiceMock.Setup(x => x.GuardarImagen(It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Editar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Borrar(It.IsAny<string>(), It.IsAny<string>()));

            var loggerMock = new Mock<ILogger<CampeonesController>>();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            var mapper = mappingConfig.CreateMapper();

            campeonesController = new CampeonesController(campeonServiceMock.Object, fileServiceMock.Object, mapper, loggerMock.Object);
        }

        // GET
        [Test]
        public async Task Get_GetListCampeones_ReturnsNotNull()
        {
            var result = await campeonesController.Get(new PaginacionDTO { Pagina = 1, RecordsPorPagina = 3 });
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaCampeonDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
        [Test]
        public async Task GetId_GetCampeonporId_ReturnsNotNull()
        {
            var result = await campeonesController.GetPorId(Prueba[0].Id);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var campeon = (LecturaCampeonDTO)status.Value!;
            Assert.That(campeon, Is.Not.Null);
            Assert.That(campeon.Id, Is.EqualTo(Prueba[0].Id));
        }
        [Test]
        public async Task GetId_GetCampeonporYear_ReturnsNotNull()
        {
            var result = await campeonesController.GetPorYear(Prueba[0].Year);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var campeon = (LecturaCampeonDTO)status.Value!;
            Assert.That(campeon, Is.Not.Null);
            Assert.That(campeon.Year, Is.EqualTo(Prueba[0].Year));
        }

        // POST
        [Test]
        public async Task Post_GetStatus201_Returns201()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearCampeonDTO { AutoCampeon = fileMock.Object, Year = 2000, PilotoId = Prueba[0].PilotoId };
            var result = await campeonesController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(201, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_FotoNull_Returns400()
        {
            var DTO = new CrearCampeonDTO { AutoCampeon = null, Year = 2000, PilotoId = Prueba[0].PilotoId };
            var result = await campeonesController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_PilotoInexistente_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearCampeonDTO { AutoCampeon = fileMock.Object, Year = 2000, PilotoId = Prueba[0].PilotoId };
            campeonServiceMock.Setup(x => x.ExistePiloto(It.IsAny<int>())).ReturnsAsync(false);
            var result = await campeonesController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }


        // PUT
        [Test]
        public async Task Put_GetStatus204NotContent_Return204()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearCampeonDTO { AutoCampeon = fileMock.Object, Year = 2000, PilotoId = Prueba[0].PilotoId };
            var result = await campeonesController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExiste_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearCampeonDTO { AutoCampeon = fileMock.Object, Year = 2000, PilotoId = Prueba[0].PilotoId };
            campeonServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await campeonesController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExistePiloto_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearCampeonDTO { AutoCampeon = fileMock.Object, Year = 2000, PilotoId = Prueba[0].PilotoId };
            campeonServiceMock.Setup(x => x.ExistePiloto(It.IsAny<int>())).ReturnsAsync(false);
            var result = await campeonesController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_GetStatus204NotContentFotoNull_Return204()
        {
            var DTO = new CrearCampeonDTO { AutoCampeon = null, Year = 2000, PilotoId = Prueba[0].PilotoId };
            var result = await campeonesController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        // DELETE

        [Test]
        public async Task Delete_Get204NotContent_Return204()
        {
            var result = await campeonesController.Delete(Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }

        [Test]
        public async Task Delete_Get400BadRequest_Return400()
        {
            campeonServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await campeonesController.Delete(Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
    }
}
