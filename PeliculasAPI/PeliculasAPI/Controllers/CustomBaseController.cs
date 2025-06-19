using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Utilidades;

namespace PeliculasAPI.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        private readonly Negocio negocio;
        private readonly IMapper mapper;

        public CustomBaseController(Negocio negocio, IMapper mapper)
        {
            this.negocio = negocio;
            this.mapper = mapper;
        }

        protected async Task<ActionResult<List<TDTO>>> GetBase<TEntity, TDTO>() where TEntity : class
        {
            var entidad = await negocio.Set<TEntity>().ToListAsync();
            return Ok(mapper.Map<List<TDTO>>(entidad));
        }

        protected async Task<ActionResult<TDTO>> GetIdBase<TEntity, TDTO>(int id) where TEntity : class, IId
        {
            var entidad = await negocio.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (entidad == null) return NotFound();
            return Ok(mapper.Map<TDTO>(entidad));
        }

        protected async Task<ActionResult> PostBase<TEntity, TCreacion,TLectura>([FromBody] TCreacion creacionDTO, string nombreRuta)
            where TEntity : class, IId
        {
            var entidad = mapper.Map<TEntity>(creacionDTO);
            negocio.Add(entidad);
            await negocio.SaveChangesAsync();
            var lectura = mapper.Map<TLectura>(entidad);
            return CreatedAtRoute(nombreRuta, new { id = entidad.Id }, lectura);
        }

        protected async Task<ActionResult> PutBase<TEntity, TCreacion>([FromBody] TCreacion creacionDTO, int id)
            where TEntity : class, IId
        {
            var entidad = mapper.Map<TEntity>(creacionDTO);
            entidad.Id = id;
            negocio.Update(entidad);
            await negocio.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> DeleteBase<TEntity>(int id) where TEntity : class, IId, new()
        {
            if(!await negocio.Set<TEntity>().AnyAsync(x => x.Id == id)) return NotFound();
            negocio.Remove(new TEntity() { Id = id});
            await negocio.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult<List<TLectura>>> GetPaginadoBase<TEntity, TLectura>(PaginacionDTO paginacionDTO)
            where TEntity : class
        {
            var query = negocio.Set<TEntity>().AsQueryable();
            await HttpContext.InsertarRegistrosTotalesBDCabecera(query);
            var lectura = mapper.Map<List<TLectura>>(await query.Paginar(paginacionDTO).AsNoTracking().ToListAsync());
            if (lectura.Count == 0) return NotFound();
            return Ok(lectura);
        }
    }

    public interface IId
    {
        public int Id { get; set; }
    }
}
