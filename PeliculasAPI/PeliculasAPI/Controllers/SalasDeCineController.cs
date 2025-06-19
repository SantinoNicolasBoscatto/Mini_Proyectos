using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/SalasCine")]
    public class SalasDeCineController : CustomBaseController
    {
        private readonly Negocio negocio;

        public SalasDeCineController(Negocio negocio, IMapper mapper) : base(negocio, mapper)
        {
            this.negocio = negocio;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaSalaDeCineDTO>>> Get()
        {
            return await GetBase<SalasDeCine, LecturaSalaDeCineDTO>();
        }

        [HttpGet("{id:int}", Name = "SalaPorId")]
        public async Task<ActionResult<LecturaSalaDeCineDTO>> GetId(int id)
        {
            return await GetIdBase<SalasDeCine, LecturaSalaDeCineDTO>(id);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CrearSalaDeCineDTO salaDTO)
        {
            return await PostBase<SalasDeCine, CrearSalaDeCineDTO, LecturaSalaDeCineDTO>(salaDTO, "SalaPorId");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearSalaDeCineDTO salaDTO, int id)
        {
            return await PutBase<SalasDeCine, CrearSalaDeCineDTO>(salaDTO, id);
        }


        [HttpGet("Cercanos")]
        public async Task<ActionResult<List<LecturaSalaDeCineDTO>>> GetCercanos([FromQuery] SalaDeCineCercanoFiltroDTO filtroDTO)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var userUbicacion = geometryFactory.CreatePoint(new Coordinate(filtroDTO.Longitud, filtroDTO.Latitud));
            var salasCercanas = await negocio.SalasDeCines
                                .OrderBy(x => x.Ubicacion.Distance(userUbicacion))
                                .Where(x => x.Ubicacion.IsWithinDistance(userUbicacion,filtroDTO.Distancia *1000))
                                .Select(x => new SalaDeCineCercanoDTO
                                {
                                    Id = x.Id,
                                    Nombre = x.Nombre!,
                                    Latitud = x.Ubicacion.Y,
                                    Longitud = x.Ubicacion.X,
                                    DistanciaEnMetros = Math.Round(x.Ubicacion.Distance(userUbicacion))
                                }).ToListAsync();
            return Ok(salasCercanas);
        }
    }
}
