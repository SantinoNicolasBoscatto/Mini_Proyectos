using EFCorePeliculas.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/cine")]
    public class CineController : ControllerBase
    {
        private readonly Negocio negocio;

        public CineController(Negocio negocio)
        {
            this.negocio = negocio;
        }

        [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {
            var genero = await negocio.Cines
            .Include(x => x.CineOferta)
            .Include(x => x.SalasDeCineHash)
            .ToListAsync();
            return genero;
        }
    }
}
