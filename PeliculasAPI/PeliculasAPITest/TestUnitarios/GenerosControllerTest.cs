using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPITest.TestUnitarios
{
    [TestClass]
    public class GenerosControllerTest : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosGeneros()
        {
            // Preparacion
            var nombreBD = Guid.NewGuid().ToString();
            var negocio = ConstruirContext(nombreBD);
            var mapper = ConfigurarMapper();

            negocio.Add(new Genero() { Id = 33, Nombre = "Gen1" });
            negocio.Add(new Genero() { Id = 34, Nombre = "Gen2" });
            await negocio.SaveChangesAsync();
            var negocio2 = ConstruirContext(nombreBD);
            var controller = new GenerosController(negocio2, mapper);

            // Ejecucion
            var respuesta = await controller.Get();
            var generos = respuesta.Result as OkObjectResult;

            // Verificacion
            Assert.AreEqual(200, generos!.StatusCode);
        }

        [TestMethod]
        public async Task ObtenerGeneroPorIdNoExistente()
        {
            // Preparacion
            var nombreBD = Guid.NewGuid().ToString();
            var negocio = ConstruirContext(nombreBD);
            var mapper = ConfigurarMapper();
            var negocio2 = ConstruirContext(nombreBD);
            // Ejecucion
            var controller = new GenerosController(negocio2, mapper);
            var respuesta = await controller.GetId(1);
            var result = respuesta.Result as StatusCodeResult;
            // Verificacion
            Assert.AreEqual(404, result!.StatusCode);
        }

        [TestMethod]
        public async Task CrearGenero()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var negocio = ConstruirContext(nombreBD);
            var mapper = ConfigurarMapper();
            var nuevoGenero = new CrearGeneroDTO() { Nombre = "Nombre" };
            var controller = new GenerosController(negocio, mapper);

            var respuesta = await controller.Post(nuevoGenero);
            var resultado = respuesta as CreatedAtRouteResult;
            Assert.IsNotNull(resultado);

            var contexto2 = ConstruirContext(nombreBD);
            var count = await contexto2.Generos.CountAsync();
            Assert.AreEqual(1, count);

        }

        [TestMethod]
        public async Task ModGenero()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var negocio = ConstruirContext(nombreBD);
            var mapper = ConfigurarMapper();

            negocio.Add(new Genero() { Id = 1, Nombre = "nombreBD" });
            await negocio.SaveChangesAsync();

            var negocio2 = ConstruirContext(nombreBD);
            var controller = new GenerosController(negocio2, mapper);
            var nuevoGenero = new CrearGeneroDTO() { Nombre = "Nombre" };
            var id = 1;
            var respuesta = await controller.Put(nuevoGenero, id);
            var resultado = respuesta as StatusCodeResult;
            Assert.AreEqual(204, resultado!.StatusCode);

            var negocio3 = ConstruirContext(nombreBD);
            var exist = await negocio3.Generos.AnyAsync(x => x.Nombre == nuevoGenero.Nombre);
            Assert.IsTrue(exist);
        }
    }
}
