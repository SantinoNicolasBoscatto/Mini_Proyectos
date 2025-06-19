using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;
using NascarPage;
using NascarPage.Repositorio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using NascarPage.DTOs;
using NascarPageNUnitTests.Helpers;

namespace NascarPageNUnitTests.Repositorio
{
    [TestFixture]
    public class CampeonServiceNUnitTests
    {
        private ICampeonService campeonService = null!;
        private Campeon Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaCampeones = fixture.CreateMany<Campeon>().ToList();
            Prueba = listaCampeones[0];

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            var dbContextFake = new Negocio(options);
            dbContextFake.AddRange(listaCampeones);
            dbContextFake.SaveChanges();

            var httpContextMock = new Mock<IHttpContextAccessor>();
            httpContextMock.SetupAllProperties();
            httpContextMock.Object.HttpContext = new DefaultHttpContext();

            EntityCleaner.DetachAllEntities(dbContextFake);
            campeonService = new CampeonService(dbContextFake, httpContextMock.Object);
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetCampeones_InputPaginacionDTO_ReturnNotNull(int recordsPorPagina)
        {
            var list = await campeonService.GetCampeones(new PaginacionDTO { Pagina = 1, RecordsPorPagina = recordsPorPagina });
            Assert.That(list, Is.Not.Null);
            Assert.That(list.Count, Is.EqualTo(recordsPorPagina));
        }
        [Test]
        public async Task GetCampeonId_RecibirCampeonPorId_ReturnsNotNull()
        {

            var campeon = await campeonService.GetCampeonId(Prueba.Id);
            Assert.That(campeon, Is.Not.Null);
            Assert.That(Prueba.Id, Is.EqualTo(campeon!.Id));
        }
        [Test]
        public async Task GetCampeonYear_RecibirCampeonPorYear_ReturnsNotNull()
        {

            var campeon = await campeonService.GetCampeonYear(Prueba.Year);
            Assert.That(campeon, Is.Not.Null);
            Assert.That(Prueba.Year, Is.EqualTo(campeon!.Year));
        }
        [Test]
        public async Task AgregarCampeon_AgregarCampeonBD_ReturnsTrue()
        {
            var campeon = new Campeon
            {
                AutoCampeon = "",
                PilotoId = Prueba.PilotoId,
                Year = 2033
            };
            await campeonService.AgregarCampeon(campeon);
            var autoAgregado = await campeonService.GetCampeonId(campeon.Id);
            Assert.That(autoAgregado, Is.Not.Null);
            Assert.That(autoAgregado!.Id, Is.EqualTo(campeon.Id));
        }
        [Test]
        public async Task ModificarCampeon_VerificarModificacion_ReturnsTrue()
        {
            var campeonBD = await campeonService.GetCampeonId(Prueba.Id);
            campeonBD!.AutoCampeon = "HolaSoyUnaFoto";
            await campeonService.ModificarCampeon(campeonBD);
            var mod = await campeonService.GetCampeonId(Prueba.Id);
            Assert.That(mod!.AutoCampeon, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarCampeon_CapturarString_ReturnsNull()
        {
            var campeonBD = await campeonService.GetCampeonId(Prueba.Id);
            var expectedString = campeonBD!.AutoCampeon;
            var result = await campeonService.EliminarCampeon(Prueba.Id);
            Assert.That(result, Is.EqualTo(expectedString));
            Assert.That(await campeonService.EliminarCampeon(Prueba.Id), Is.Null);
        }
        [Test]
        public async Task Existe_VerificarCampeonExiste_ReturnsTrue()
        {
            var result = await campeonService.Existe(Prueba.Id);
            Assert.That(result, Is.True);
        }
        [Test]
        public async Task EsCampeon_VerificarCampeon_ReturnsTrue()
        {
            var campeon = await campeonService.GetCampeonId(Prueba.Id)!;
            var result = await campeonService.EsCampeon(campeon!.PilotoId);
            Assert.That(result, Is.True);
        }
    }
}
