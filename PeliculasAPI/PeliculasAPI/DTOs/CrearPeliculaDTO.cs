using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Entidades;
using PeliculasAPI.Utilidades;
using PeliculasAPI.Validaciones;

namespace PeliculasAPI.DTOs
{
    public class CrearPeliculaDTO
    {
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime Estreno { get; set; }
        [PesoArchivoValidacion(4)]
        [ExtensionArchivoValidator(GrupoExtensionArchivo.Imagen)]
        public IFormFile? Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> ListaGenerosIds { get; set; } = null!;

        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorPeliculasCreacionDTO>>))]
        public List<ActorPeliculasCreacionDTO>? ListActores { get; set; }
    }
}
