using AutoMapper;
using Microsoft.AspNetCore.OutputCaching;
using MinimalAPIpeliculas.Repositorio;

namespace MinimalAPIpeliculas.DTO
{
    public class CrearComentariosEndPointDTO
    {
        public int peliculaId { get; set; }
        public CrearComentarioDTO crearComentarioDTO { get; set; }
        public IComentarioService comentarioService { get; set; }
        public IMapper mapper { get; set; }
        public IPeliculasService peliculasService { get; set; }
        public IOutputCacheStore cache { get; set; }
        public IUsuarioService usuarioService { get; set; }
        
    }
}
