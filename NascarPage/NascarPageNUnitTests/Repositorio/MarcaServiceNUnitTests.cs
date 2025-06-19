using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using NascarPage.Entitys;
using NascarPage;
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
    public class MarcaServiceNUnitTests
    {
        private IMarcaService marcaService = null!;
        private int idPrueba;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaMarca = fixture.CreateMany<Marca>().ToList();
            idPrueba = listaMarca[0].Id;

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            var dbContextFake = new Negocio(options);
            dbContextFake.AddRange(listaMarca);
            dbContextFake.SaveChanges();

            EntityCleaner.DetachAllEntities(dbContextFake);
            marcaService = new MarcaService(dbContextFake);
        }

        [Test]
        public async Task GetMarcas_RecibirListaMarcas_ReturnNotNull()
        {
            var resultados = await marcaService.GetMarcas();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetMarcaId_RecibirMarcaPorId_ReturnsNotNull()
        {
            var marca = await marcaService.GetMarcaPorId(idPrueba);
            Assert.That(marca, Is.Not.Null);
            Assert.That(idPrueba, Is.EqualTo(marca!.Id));
        }
        [Test]
        public async Task AgregarMarca_AgregarMarcaBD_ReturnsTrue()
        {
            var marca = new Marca
            {
                Foto = "",
                Id = 1,
                Nombre = "1"
            };
            await marcaService.AgregarMarca(marca);
            var marcaAgregada = await marcaService.GetMarcaPorId(marca.Id);
            Assert.That(marcaAgregada, Is.Not.Null);
            Assert.That(marcaAgregada!.Id, Is.EqualTo(marca.Id));
        }
        [Test]
        public async Task ModificarMarca_VerificarModificacion_ReturnsTrue()
        {
            var marcaBD = await marcaService.GetMarcaPorId(idPrueba);
            marcaBD!.Foto = "HolaSoyUnaFoto";
            await marcaService.ActulizarMarca(marcaBD);
            var mod = await marcaService.GetMarcaPorId(idPrueba);
            Assert.That(mod!.Foto, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarMarca_CapturarString_ReturnsNull()
        {
            var marcaBD = await marcaService.GetMarcaPorId(idPrueba);
            var expectedString = marcaBD!.Foto;
            var result = await marcaService.EliminarMarca(idPrueba);
            Assert.That(result.Item1, Is.EqualTo(expectedString));
            var r2 = await marcaService.EliminarMarca(idPrueba);
            Assert.That(r2.Item1, Is.Null);
        }
    }
}
