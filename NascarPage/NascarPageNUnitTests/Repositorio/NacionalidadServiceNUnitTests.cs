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
    [TestFixture]
    public class NacionalidadServiceNUnitTests
    {
        private INacionalidadService nacionalidadService = null!;
        private Nacionalidad Prueba = null!;
        private Negocio dbContextFake = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaNacion = fixture.CreateMany<Nacionalidad>().ToList();
            Prueba = listaNacion[0];

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            dbContextFake = new Negocio(options);
            dbContextFake.AddRange(listaNacion);
            dbContextFake.SaveChanges();

            nacionalidadService = new NacionalidadService(dbContextFake);
            EntityCleaner.DetachAllEntities(dbContextFake);
        }

        [Test]
        public async Task GetNaciones_RecibirListaNaciones_ReturnNotNull()
        {
            var resultados = await nacionalidadService.GetNacionalidades();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetNacionId_RecibirNacionPorId_ReturnsNotNull()
        {
            var nacion = await nacionalidadService.GetNacionalidadPorId(Prueba.Id);
            Assert.That(nacion, Is.Not.Null);
            Assert.That(Prueba.Id, Is.EqualTo(nacion!.Id));
        }
        [Test]
        public async Task AgregarNacion_AgregarNacionBD_ReturnsTrue()
        {
            var nacion = new Nacionalidad
            {
                Bandera = "",
                Nombre = ""
            };
            await nacionalidadService.AgregarNacionalidad(nacion);
            var nacionAgregada = await nacionalidadService.GetNacionalidadPorId(nacion.Id);
            Assert.That(nacionAgregada, Is.Not.Null);
            Assert.That(nacionAgregada!.Id, Is.EqualTo(nacion.Id));
        }
        [Test]
        public async Task ModificarNacion_VerificarModificacion_ReturnsTrue()
        {
            var nacionBD = await nacionalidadService.GetNacionalidadPorId(Prueba.Id);
            nacionBD!.Bandera = "HolaSoyUnaFoto";
            await nacionalidadService.ModificarNacionalidad(nacionBD);
            var mod = await nacionalidadService.GetNacionalidadPorId(Prueba.Id);
            Assert.That(mod!.Bandera, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarNacion_CapturarString_ReturnsNull()
        {
            var nacionBD = await nacionalidadService.GetNacionalidadPorId(Prueba.Id);
            var expectedString = nacionBD!.Bandera;
            var result = await nacionalidadService.EliminarNacionalidad(Prueba.Id);
            Assert.That(result, Is.EqualTo(expectedString));
            Assert.That(await nacionalidadService.EliminarNacionalidad(Prueba.Id), Is.Null);
        }
        [Test]
        public async Task Existe_VerificarNacionExiste_ReturnsTrue()
        {
            var result = await nacionalidadService.Existe(Prueba.Id);
            Assert.That(result, Is.True);
        }
    }
}
