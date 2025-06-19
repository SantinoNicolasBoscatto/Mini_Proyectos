using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;
using NascarPage.Repositorio;
using NascarPage;
using NascarPageNUnitTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using NascarPage.DTOs;

namespace NascarPageNUnitTests.Repositorio
{
    [TestFixture]
    public class GaleriaServiceNUnitTests
    {
        private IGaleriaService galeriaService = null!;
        private int idPrueba;
        private int ronda;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var galeria = fixture.CreateMany<Galeria>().ToList();
            idPrueba = galeria[0].Id;
            ronda = galeria[0].Ronda;

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            var dbContextFake = new Negocio(options);
            dbContextFake.AddRange(galeria);
            dbContextFake.SaveChanges();

            var httpContextMock = new Mock<IHttpContextAccessor>();
            httpContextMock.SetupAllProperties();
            httpContextMock.Object.HttpContext = new DefaultHttpContext();

            galeriaService = new GaleriaService(dbContextFake, httpContextMock.Object);
            EntityCleaner.DetachAllEntities(dbContextFake);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetGaleria_RecibirGaleria_ReturnNotNull(int recordsPorPagina)
        {
            var resultados = await galeriaService.GetFotos(new PaginacionDTO { Pagina = 1, RecordsPorPagina = recordsPorPagina });
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.EqualTo(recordsPorPagina));
        }
        [Test]
        public async Task GetGaleriaId_RecibirGaleriaPorId_ReturnsNotNull()
        {
            var galeria = await galeriaService.GetFotosPorId(idPrueba);
            Assert.That(galeria, Is.Not.Null);
            Assert.That(idPrueba, Is.EqualTo(galeria!.Id));
        }
        [Test]
        public async Task GetGaleriaOrden_RecibirGaleriaPorOrdenr_ReturnsNotNull()
        {
            var galeria = await galeriaService.GetFotosPorRonda(ronda);
            Assert.That(galeria, Is.Not.Null);
            Assert.That(ronda, Is.EqualTo(galeria!.Ronda));
        }
        [Test]
        public async Task AgregarGaleria_AgregarGaleriaBD_ReturnsTrue()
        {
            var galeria = new Galeria
            {
                FotoUno = "",
                FotoDos = "",
                FotoTres = "",
                Ronda = 1
            };
            await galeriaService.AgregarGaleria(galeria);
            var galeriaAgregada = await galeriaService.GetFotosPorId(galeria.Id);
            Assert.That(galeriaAgregada, Is.Not.Null);
            Assert.That(galeriaAgregada!.Id, Is.EqualTo(galeria.Id));
        }
        [Test]
        public async Task ModificarGaleria_VerificarModificacion_ReturnsTrue()
        {
            var galeriaBD = await galeriaService.GetFotosPorId(idPrueba);
            galeriaBD!.FotoUno = "HolaSoyUnaFoto";
            await galeriaService.ModificarGaleria(galeriaBD);
            var mod = await galeriaService.GetFotosPorId(idPrueba);
            Assert.That(mod!.FotoUno, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarGaleria_CapturarString_ReturnsNull()
        {
            var galeriaBD = await galeriaService.GetFotosPorId(idPrueba);
            var expectedString = galeriaBD!.FotoUno;
            var result = await galeriaService.Eliminar(idPrueba);
            Assert.That(result.Item1, Is.EqualTo(expectedString));
            var r2 = await galeriaService.Eliminar(idPrueba);
            Assert.That(r2.Item1, Is.Null);
        }
        [Test]
        public async Task Existe_VerificarGaleriaExiste_ReturnsTrue()
        {
            var result = await galeriaService.Existe(idPrueba);
            Assert.That(result, Is.True);
        }

    }
}
