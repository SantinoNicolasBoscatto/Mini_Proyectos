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

namespace NascarPageNUnitTests.Repositorio
{
    public class TablasServiceNUnitTests
    {
        private ITablaService tablaService = null!;
        private Negocio dbContextFake = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var tabla = fixture.CreateMany<PosicionCampeonatoRegular>(40).ToList();
            var tablaPlayoff = fixture.CreateMany<PosicionPlayoff>(40).ToList();
            var manofactura = fixture.CreateMany<PosicionManofactura>().ToList();
            var calendario = fixture.Create<Calendario>();

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            dbContextFake = new Negocio(options);
            dbContextFake.AddRange(tabla);
            dbContextFake.AddRange(tablaPlayoff);
            dbContextFake.AddRange(manofactura);
            dbContextFake.Add(calendario);
            dbContextFake.SaveChanges();

            EntityCleaner.DetachAllEntities(dbContextFake);
            tablaService = new TablasService(dbContextFake);
        }

        [Test]
        public async Task GetTabla_RecibirListaPosiciones_ReturnNotNull()
        {
            var resultados = await tablaService.GetTablaRegular();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetTablaPlayoff_RecibirPlayoff_ReturnNotNull()
        {
            var resultados = await tablaService.GetTablaPlayOffReducida();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetTablaPlayoff_RecibirPlayoff20Pilotos_ReturnCount20()
        {
            var calendario = await dbContextFake.Calendario.AsTracking().FirstOrDefaultAsync();
            calendario!.EventoActual = 1;
            await dbContextFake.SaveChangesAsync();
            var resultados = await tablaService.GetTablaPlayOffReducida();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.EqualTo(20));
        }
        [Test]
        [TestCase(28)]
        [TestCase(30)]
        public async Task GetTablaPlayoff_RecibirPlayoff16Pilotos_ReturnCount16(int fecha)
        {
            var calendario = await dbContextFake.Calendario.AsTracking().FirstOrDefaultAsync();
            calendario!.EventoActual = fecha;
            await dbContextFake.SaveChangesAsync();
            var resultados = await tablaService.GetTablaPlayOffReducida();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.EqualTo(16));
        }
        [Test]
        [TestCase(31)]
        [TestCase(33)]
        public async Task GetTablaPlayoff_RecibirPlayoff12Pilotos_ReturnCount12(int fecha)
        {
            var calendario = await dbContextFake.Calendario.AsTracking().FirstOrDefaultAsync();
            calendario!.EventoActual = fecha;
            await dbContextFake.SaveChangesAsync();
            var resultados = await tablaService.GetTablaPlayOffReducida();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.EqualTo(12));
        }
        [Test]
        [TestCase(34)]
        [TestCase(36)]
        public async Task GetTablaPlayoff_RecibirPlayoff8Pilotos_ReturnCount8(int fecha)
        {
            var calendario = await dbContextFake.Calendario.AsTracking().FirstOrDefaultAsync();
            calendario!.EventoActual = fecha;
            await dbContextFake.SaveChangesAsync();
            var resultados = await tablaService.GetTablaPlayOffReducida();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.EqualTo(8));
        }
        [Test]
        public async Task GetTablaPlayoff_RecibirPlayoff4Pilotos_ReturnCount4()
        {
            var calendario = await dbContextFake.Calendario.AsTracking().FirstOrDefaultAsync();
            calendario!.EventoActual = 37;
            await dbContextFake.SaveChangesAsync();
            var resultados = await tablaService.GetTablaPlayOffReducida();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.EqualTo(4));
        }

        [Test]
        public async Task GetManofactura_ReturnNotNull()
        {
            var result = await tablaService.GetManofacturas();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.GreaterThan(1));
        }

        // TEST DE REINICIO DE TEMPORADA

        [Test]
        public async Task ReiniciarTablasyCarreras_ResetSeason_Returns40RowsTabla0Puntos()
        {
            await tablaService.ReiniciarTablasyCarreras();
            var calendario = await dbContextFake.Calendario.FirstAsync();
            Assert.That(1, Is.EqualTo(calendario.EventoActual));
            Assert.That(1, Is.EqualTo(calendario.Id));
            Assert.That(36, Is.EqualTo(calendario.CantidadDeEventos));
            var posicionRegular = await dbContextFake.TablaPosicionesCampeonatoRegular.ToListAsync();
            foreach (var item in posicionRegular)
            {
                if (item.Puntos != 0 || item.Wins != 0 || item.Top5s != 0) Assert.Fail();
            }
        }
    }
}
