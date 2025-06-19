using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using NascarPage;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;
using NascarPageNUnitTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NascarPageNUnitTests.Repositorio
{
    [TestFixture]
    public class AutoServiceNUnitTests
    {
        private IAutoService autoService = null!;
        private Auto Prueba = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaAutos = fixture.CreateMany<Auto>().ToList();
            Prueba = listaAutos[0];

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            var dbContextFake = new Negocio(options);
            dbContextFake.AddRange(listaAutos);
            dbContextFake.SaveChanges();

            EntityCleaner.DetachAllEntities(dbContextFake);
            autoService = new AutoService(dbContextFake);
        }
        [Test]
        public async Task GetAutos_RecibirListaAutos_ReturnNotNull()
        {
            var resultados = await autoService.GetAutos();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetAutoId_RecibirAutoPorId_ReturnsNotNull()
        {
            var auto = await autoService.GetAutoId(Prueba.Id);
            Assert.That(auto, Is.Not.Null);
            Assert.That(Prueba.Id, Is.EqualTo(auto!.Id));
        }
        [Test]
        public async Task AgregarAuto_AgregarAutoBD_ReturnsTrue()
        {
            var auto = new Auto
            {
                Foto = "",
                MarcaId = Prueba.MarcaId,
                PilotoId = Prueba.PilotoId
            };
            await autoService.AgregarAuto(auto);
            var autoAgregado = await autoService.GetAutoId(auto.Id);
            Assert.That(autoAgregado, Is.Not.Null);
            Assert.That(autoAgregado!.Id, Is.EqualTo(auto.Id));
        }
        [Test]
        public async Task ModificarAuto_VerificarModificacion_ReturnsTrue()
        {
            var autoBD = await autoService.GetAutoId(Prueba.Id);
            autoBD!.Foto = "HolaSoyUnaFoto";
            await autoService.ModificarAuto(autoBD);
            var mod = await autoService.GetAutoId(Prueba.Id);
            Assert.That(mod!.Foto, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarAuto_CapturarString_ReturnsNull()
        {
            var autoBD = await autoService.GetAutoId(Prueba.Id);
            var expectedString = autoBD!.Foto;
            var result = await autoService.EliminarAuto(Prueba.Id);
            Assert.That(result, Is.EqualTo(expectedString));
            Assert.That(await autoService.EliminarAuto(Prueba.Id), Is.Null);
        }
        [Test]
        public async Task Existe_VerificarAutoExiste_ReturnsTrue()
        {
            var result = await autoService.Existe(Prueba.Id);
            Assert.That(result, Is.True);
        }
    }
}
