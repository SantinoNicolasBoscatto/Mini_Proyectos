using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Repositorios;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        public HomeController(IRepositorioProyectos repositorioProyectos, IServicioEmail servicioEmail)
        {
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            ViewBag.Desc = "FullStack Junior Developer especializado en .NET";
            var modelo = new HomeIndexViewModel() { Proyectos = repositorioProyectos.Obtener() };
            return View(modelo);
        }
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(EmailDTO Contacto) 
        { 
            await servicioEmail.Enviar(Contacto);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias() { 
            
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
