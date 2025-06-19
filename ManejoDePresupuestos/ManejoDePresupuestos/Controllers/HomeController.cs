using Microsoft.AspNetCore.Mvc;

namespace ManejoDePresupuestos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NoEncontrado()
        {
            return View();
        }
    }
}
