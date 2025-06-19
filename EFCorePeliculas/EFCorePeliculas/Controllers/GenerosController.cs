using EFCorePeliculas.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly Negocio _negocio;

        public GenerosController(Negocio negocio)
        {
            _negocio = negocio;
        }



        [HttpPost]
        public async Task<ActionResult> Post(Genero genero)
        {
            _negocio.Add(genero);
            await _negocio.SaveChangesAsync();
            return Ok(genero);
        }







        [HttpGet]
        public async Task<IEnumerable<Genero>> GetGeneros()
        {
            return await _negocio.Generos.ToListAsync();
        }
        [HttpGet("Filtro")]
        public async Task<IEnumerable<Genero>> Filtrado(string name)
        {
            return await _negocio.Generos.Where
                (x => x.Name.Contains(name) && x.Name.StartsWith("A")).OrderByDescending(x => x.Identificador).ToListAsync();
        }
        [HttpGet("Primer")]
        public async Task<ActionResult<Genero>> Primer()
        {
            var r = await _negocio.Generos.OrderByDescending(x=>x.Identificador).FirstOrDefaultAsync(x => x.Name.StartsWith("A"));
            if(r == null)return NotFound();
            return r; 
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> GetId(int id)
        {
            var r = await _negocio.Generos.FirstOrDefaultAsync(x => x.Identificador == id);
            if (r == null) return NotFound();
            return r;
        }
        [HttpGet("Paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPag(int ap)
        {
            var generos = await _negocio.Generos.Skip((ap-1)*2).Take(2).ToListAsync();
            return generos;
        }
    }
}
