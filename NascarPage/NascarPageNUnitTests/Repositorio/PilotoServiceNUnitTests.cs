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
    public class PilotoServiceNUnitTests
    {
        private IPilotoService pilotosService = null!;
        private Piloto Prueba = null!;
        private Negocio dbContextFake = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaNacion = fixture.CreateMany<Piloto>().ToList();
            Prueba = listaNacion[0];
            foreach (var item in listaNacion)
            {
                item.Numero = "00";
            }

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            dbContextFake = new Negocio(options);
            dbContextFake.AddRange(listaNacion);
            dbContextFake.SaveChanges();

            pilotosService = new PilotoService(dbContextFake);
            EntityCleaner.DetachAllEntities(dbContextFake);
        }

        [Test]
        public async Task GetPilotos_RecibirListaPilotos_ReturnNotNull()
        {
            var resultados = await pilotosService.GetPilotos();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetPilotoId_RecibirPilotoPorId_ReturnsNotNull()
        {
            var auto = await pilotosService.GetPilotoPorId(Prueba.Id);
            Assert.That(auto, Is.Not.Null);
            Assert.That(Prueba.Id, Is.EqualTo(auto!.Id));
        }
        [Test]
        public async Task AgregarNacion_AgregarNacionBD_ReturnsTrue()
        {
            var piloto = new Piloto
            {
                Campeonatos = 0,
                CarrerasGanadas = 0,
                Edad = 0, 
                NacionalidadId = Prueba.Nacionalidad.Id,
                EnActivo = true,
                FotoPiloto = "",
                Nombre = "",
                Numero = "",
                Poles = 0,
                Top5s = 0,
                Top10s = 0,
            };
            await pilotosService.PostPilotos(piloto);
            var pilotoAgregado = await pilotosService.GetPilotoPorId(piloto.Id);
            Assert.That(pilotoAgregado, Is.Not.Null);
            Assert.That(pilotoAgregado!.Id, Is.EqualTo(piloto.Id));
        }
        [Test]
        public async Task ModificarNacion_VerificarModificacion_ReturnsTrue()
        {
            var pistaBD = await pilotosService.GetPilotoPorId(Prueba.Id);
            pistaBD!.FotoPiloto = "HolaSoyUnaFoto";
            await pilotosService.ModificarPiloto(pistaBD);
            var mod = await pilotosService.GetPilotoPorId(Prueba.Id);
            Assert.That(mod!.FotoPiloto, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarNacion_CapturarString_ReturnsNull()
        {
            var pistaBD = await pilotosService.GetPilotoPorId(Prueba.Id);
            var expectedString = pistaBD!.FotoPiloto;
            var result = await pilotosService.EliminarPiloto(Prueba.Id);
            Assert.That(result.Item1, Is.EqualTo(expectedString));
            var r2 = await pilotosService.EliminarPiloto(Prueba.Id);
            Assert.That(r2.Item1, Is.Null);
        }
        [Test]
        public async Task Existe_VerificarNacionExiste_ReturnsTrue()
        {
            var result = await pilotosService.Existe(Prueba.Id);
            Assert.That(result, Is.True);
        }
    }
}
