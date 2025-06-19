using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NascarPage.Repositorio;
using NascarPage;
using NascarPageNUnitTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NascarPage.Entitys;

namespace NascarPageNUnitTests.Repositorio
{
    public class NoticiaServiceNUnitTests
    {
        private INoticiaService noticiaService = null!;
        private Noticia Prueba = null!;
        private Negocio dbContextFake = null!;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaNacion = fixture.CreateMany<Noticia>().ToList();
            Prueba = listaNacion[0];

            var options = new DbContextOptionsBuilder<Negocio>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            dbContextFake = new Negocio(options);
            dbContextFake.AddRange(listaNacion);
            dbContextFake.SaveChanges();

            EntityCleaner.DetachAllEntities(dbContextFake);
            noticiaService = new NoticiaService(dbContextFake);
        }

        [Test]
        public async Task GetNaciones_RecibirListaNaciones_ReturnNotNull()
        {
            var resultados = await noticiaService.GetNoticias();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetNacionId_RecibirNacionPorId_ReturnsNotNull()
        {
            var nacion = await noticiaService.GetNoticiaId(Prueba.Id);
            Assert.That(nacion, Is.Not.Null);
            Assert.That(Prueba.Id, Is.EqualTo(nacion!.Id));
        }
        [Test]
        public async Task AgregarNacion_AgregarNacionBD_ReturnsTrue()
        {
            var noticia = new Noticia
            {
                Detalles = "",
                Foto = "",
                Titulo = ""
            };
            await noticiaService.AgregarNoticia(noticia);
            var noticiaAgregada = await noticiaService.GetNoticiaId(noticia.Id);
            Assert.That(noticiaAgregada, Is.Not.Null);
            Assert.That(noticiaAgregada!.Id, Is.EqualTo(noticia.Id));
        }
        [Test]
        public async Task ModificarNacion_VerificarModificacion_ReturnsTrue()
        {
            var nacion = await noticiaService.GetNoticiaId(Prueba.Id);
            nacion!.Foto = "HolaSoyUnaFoto";
            await noticiaService.ModificarNoticia(nacion);
            var mod = await noticiaService.GetNoticiaId(Prueba.Id);
            Assert.That(mod!.Foto, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarNacion_CapturarString_ReturnsNull()
        {
            var noticiaBD = await noticiaService.GetNoticiaId(Prueba.Id);
            var expectedString = noticiaBD!.Foto;
            var result = await noticiaService.EliminarNoticia(Prueba.Id);
            Assert.That(result, Is.EqualTo(expectedString));
            Assert.That(await noticiaService.EliminarNoticia(Prueba.Id), Is.Null);
        }
        [Test]
        public async Task Existe_VerificarNacionExiste_ReturnsTrue()
        {
            var result = await noticiaService.Existe(Prueba.Id);
            Assert.That(result, Is.True);
        }
    }
}
