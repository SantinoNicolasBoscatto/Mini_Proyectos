using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTO;
using EFCorePeliculas.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class AutoresController : ControllerBase
    {
        private readonly Negocio _negocio;
        private readonly IMapper _mapper;

        public AutoresController(Negocio negocio, IMapper mapper)
        {
            _negocio = negocio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActoresDTO>> GetActors()
        {
            var actores = await _negocio.Actors.Select(x => new ActoresDTO { IdActor = x.IdActor, Name = x.Name }).ToListAsync();
            return actores;
        }
    }
}
