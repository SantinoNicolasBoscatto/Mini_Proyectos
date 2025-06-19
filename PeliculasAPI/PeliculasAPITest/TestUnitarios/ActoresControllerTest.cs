using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using PeliculasAPI;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPITest.TestUnitarios
{
    [TestClass]
    public class ActoresControllerTest : BasePruebas
    {
        //[TestMethod]
        //public async Task ObtenerActoresPaginados()
        //{
        //    // Preparacion
        //    var nombreBD = Guid.NewGuid().ToString();
        //    var negocio = ConstruirContext(nombreBD);
        //    var mapper = ConfigurarMapper();

        //    negocio.Actores.Add(new Actor() { Id = 1, Nombre = "Actor1", Foto = "",Nacimiento = DateTime.Now });
        //    negocio.Actores.Add(new Actor() { Id = 2, Nombre = "Actor2", Foto = "",Nacimiento = DateTime.Now });
        //    negocio.Actores.Add(new Actor() { Id = 3, Nombre = "Actor3", Foto = "",Nacimiento = DateTime.Now });
        //    await negocio.SaveChangesAsync();

        //    var negocio2 = ConstruirContext(nombreBD);
        //    var controller = new ActoresController(negocio2, mapper, null);

        //    controller.ControllerContext.HttpContext = new DefaultHttpContext();
        //    var pag1 = await controller.Get(new PeliculasAPI.DTOs.PaginacionDTO() { Pagina = 1, RecordsPorPagina = 2 });
        //    var actoresPag1 = pag1.Value;

        //    controller.ControllerContext.HttpContext = new DefaultHttpContext();
        //    var pag2 = await controller.Get(new PeliculasAPI.DTOs.PaginacionDTO() { Pagina = 2, RecordsPorPagina = 2 });
        //    var actoresPag2 = pag2.Value;

        //    controller.ControllerContext.HttpContext = new DefaultHttpContext();
        //    var pag3 = await controller.Get(new PeliculasAPI.DTOs.PaginacionDTO() { Pagina = 3, RecordsPorPagina = 2 });
        //    var actoresPag3 = pag3.Value;


        //    Assert.AreEqual(2, actoresPag1!.Count);
        //    Assert.AreEqual(1, actoresPag2!.Count);
        //    Assert.AreEqual(0, actoresPag3!.Count);
        //}

        [TestMethod]
        public async Task CrearActorConFoto()
        {
            // Preparacion
            var nombreBD = Guid.NewGuid().ToString();
            var negocio = ConstruirContext(nombreBD);
            var mapper = ConfigurarMapper();

            var content = Encoding.UTF8.GetBytes("Imagen De Prueba");
            var file = new FormFile(new MemoryStream(content), 0,content.Length,"Data","imagen.jpg");
            file.Headers = new HeaderDictionary();
            file.ContentType = "image/jpg";


            var actor = new CrearActorDTO() { Nombre = "", Nacimiento = DateTime.Now, Foto = file};
            var mock = new Mock<IFilesService>();
            mock.Setup(x => x.GuardarImagen("actores", file)).ReturnsAsync("url");

            var str = await mock.Object.GuardarImagen("actores", file);
            var controller = new ActoresController(negocio, mapper, mock.Object);
            var respuesta = await controller.Post(actor);
            var result = respuesta as CreatedAtRouteResult;
            Assert.AreEqual(201, result!.StatusCode);

            var contexto2 = ConstruirContext(nombreBD);
            var list = await contexto2.Actores.ToListAsync();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("url", list[0].Foto);
            Assert.AreEqual(1, mock.Invocations.Count);
        }
    }
}
