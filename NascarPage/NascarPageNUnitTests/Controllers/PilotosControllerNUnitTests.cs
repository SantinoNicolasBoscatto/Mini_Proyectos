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
    public class PilotosControllerNUnitTests
    {
        private PilotosController pilotosController = null!;
        private Mock<IPilotoService> pilotoServiceMock = null!;
        private Mock<IFilesService> fileServiceMock = null!;
        private Mock<ILogger<AutosController>> loggerMock = null!;
        private List<Piloto> Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Piloto>().ToList();
            Prueba = list;


            pilotoServiceMock = new Mock<IPilotoService>();
            pilotoServiceMock.Setup(x => x.GetPilotos()).ReturnsAsync(list);
            pilotoServiceMock.Setup(x => x.GetCampeones()).ReturnsAsync(list);
            pilotoServiceMock.Setup(x => x.GetCarless()).ReturnsAsync(list);
            pilotoServiceMock.Setup(x => x.GetPilotoPorId(It.IsAny<int>())).ReturnsAsync(Prueba[0]);
            pilotoServiceMock.Setup(x => x.PostPilotos(It.IsAny<Piloto>()));
            pilotoServiceMock.Setup(x => x.ModificarPiloto(It.IsAny<Piloto>()));
            pilotoServiceMock.Setup(x => x.EliminarPiloto(It.IsAny<int>())).ReturnsAsync((It.IsAny<string>(), It.IsAny<string>()));
            pilotoServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(true);


            fileServiceMock = new Mock<IFilesService>();
            fileServiceMock.Setup(x => x.GuardarImagen(It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Editar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IFormFile>())).ReturnsAsync(It.IsAny<string>());
            fileServiceMock.Setup(x => x.Borrar(It.IsAny<string>(), It.IsAny<string>()));

            var loggerMock = new Mock<ILogger<PilotosController>>();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            var mapper = mappingConfig.CreateMapper();

            pilotosController = new PilotosController( mapper, pilotoServiceMock.Object, fileServiceMock.Object, loggerMock.Object);
        }


        // GET
        [Test]
        public async Task Get_GetListPilotos_ReturnsNotNull()
        {
            var result = await pilotosController.Get();
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaPilotoDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
        [Test]
        public async Task GetId_GetPilotoporId_ReturnsNotNull()
        {
            var result = await pilotosController.GetPorId(Prueba[0].Id);
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var entity = (LecturaPilotoDTO)status.Value!;
            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.EqualTo(Prueba[0].Id));
        }
        [Test]
        public async Task Get_GetListPilotosCarless_ReturnsNotNull()
        {
            var result = await pilotosController.GetCarLess();
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaPilotoDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
        [Test]
        public async Task Get_GetListPilotosCampeones_ReturnsNotNull()
        {
            var result = await pilotosController.GetCampeones();
            var status = (ObjectResult)result.Result!;
            Assert.That(200, Is.EqualTo(status.StatusCode));
            var list = (List<LecturaPilotoDTO>)status.Value!;
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }

        // POST
        [Test]
        public async Task Post_GetStatus201_Returns201()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearPilotoDTO { FotoPiloto = fileMock.Object, NacionalidadId = Prueba[0].NacionalidadId, Nombre = "Pepe", Numero = "00" };
            var result = await pilotosController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(201, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Post_FotoNull_Returns400()
        {
            var DTO = new CrearPilotoDTO { FotoPiloto = null, NacionalidadId = Prueba[0].NacionalidadId, Nombre = "Pepe", Numero = "00" };
            var result = await pilotosController.Post(DTO);
            var status = (ObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }

        // PUT
        [Test]
        public async Task Put_GetStatus204NotContent_Return204()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearPilotoDTO { FotoPiloto = fileMock.Object, NacionalidadId = Prueba[0].NacionalidadId, Nombre = "Pepe", Numero = "00" };
            var result = await pilotosController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_NoExiste_Returns400()
        {
            var fileMock = new Mock<IFormFile>();
            var DTO = new CrearPilotoDTO { FotoPiloto = fileMock.Object, NacionalidadId = Prueba[0].NacionalidadId, Nombre = "Pepe", Numero = "00" };
            pilotoServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await pilotosController.Put(DTO, Prueba[0].Id);
            var status = (BadRequestObjectResult)result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
        [Test]
        public async Task Put_GetStatus204NotContentFotoNull_Return204()
        {
            var DTO = new CrearPilotoDTO { FotoPiloto = null, NacionalidadId = Prueba[0].NacionalidadId, Nombre = "Pepe", Numero = "00" };
            var result = await pilotosController.Put(DTO, Prueba[0].Id);
            var status = (NoContentResult)result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }

        // DELETE
        [Test]
        public async Task Delete_Get204NotContent_Return204()
        {
            var result = await pilotosController.Delete(Prueba[0].Id);
            var status = (NoContentResult)result.Result!;
            Assert.That(204, Is.EqualTo(status.StatusCode));
        }

        [Test]
        public async Task Delete_Get400BadRequest_Return400()
        {
            pilotoServiceMock.Setup(x => x.Existe(It.IsAny<int>())).ReturnsAsync(false);
            var result = await pilotosController.Delete(Prueba[0].Id);
            var status = (BadRequestObjectResult)result.Result!;
            Assert.That(400, Is.EqualTo(status.StatusCode));
        }
    }
}
