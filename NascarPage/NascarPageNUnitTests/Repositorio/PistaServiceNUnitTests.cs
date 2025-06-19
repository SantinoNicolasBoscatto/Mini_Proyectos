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
    public class PistaServiceNUnitTests
    {
        private IPistaService pistaService = null!;
        private Pista Prueba = null!;
        private Negocio dbContextFake = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaNacion = fixture.CreateMany<Pista>().ToList();
            Prueba = listaNacion[0];

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            dbContextFake = new Negocio(options);
            dbContextFake.AddRange(listaNacion);
            dbContextFake.SaveChanges();

            pistaService = new PistaService(dbContextFake);
            EntityCleaner.DetachAllEntities(dbContextFake);
        }

        [Test]
        public async Task GetPistas_RecibirListaPistas_ReturnNotNull()
        {
            var resultados = await pistaService.GetPistas(false);
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetPistaId_RecibirPistaPorId_ReturnsNotNull()
        {
            var auto = await pistaService.GetPistaId(Prueba.Id);
            Assert.That(auto, Is.Not.Null);
            Assert.That(Prueba.Id, Is.EqualTo(auto!.Id));
        }
        [Test]
        public async Task AgregarPista_AgregarPistaBD_ReturnsTrue()
        {
            var pista = new Pista
            {
                Disputada = true,
                Distancia = "",
                EnElCalendario = true,
                FotoPrimaria = "",
                FotoSecundaria = "",
                FotoTerciaria = "",
                Nombre = "",
                Orden = 55,
                Vueltas = 50
            };
            await pistaService.AgregarPista(pista);
            var pistaAgregada = await pistaService.GetPistaId(pista.Id);
            Assert.That(pistaAgregada, Is.Not.Null);
            Assert.That(pistaAgregada!.Id, Is.EqualTo(pista.Id));
        }
        [Test]
        public async Task ModificarPista_VerificarModificacion_ReturnsTrue()
        {
            var pistaBD = await pistaService.GetPistaId(Prueba.Id);
            pistaBD!.FotoPrimaria = "HolaSoyUnaFoto";
            await pistaService.ModificarPista(pistaBD);
            var mod = await pistaService.GetPistaId(Prueba.Id);
            Assert.That(mod!.FotoPrimaria, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarPista_CapturarString_ReturnsNull()
        {
            var pistaBD = await pistaService.GetPistaId(Prueba.Id);
            var expectedString = pistaBD!.FotoPrimaria;
            var result = await pistaService.EliminarPista(Prueba.Id);
            Assert.That(result.Item1, Is.EqualTo(expectedString));
            var r2 = await pistaService.EliminarPista(Prueba.Id);
            Assert.That(r2.Item1, Is.Null);
        }
        [Test]
        public async Task Existe_VerificarPistaExiste_ReturnsTrue()
        {
            var result = await pistaService.Existe(Prueba.Id);
            Assert.That(result, Is.True);
        }
    }
}
