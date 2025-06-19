using AutoMapper;
using WebApiActores.DTOs;
using WebApiActores.Entitys;

namespace WebApiActores
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CrearAutorDTO, Autor>();
            CreateMap<Autor, LecturaAutorDTO>();

            CreateMap<CrearLibroDTO, Libro>()
                .ForMember(libro => libro.ListaAutoresLibros, opt => opt.MapFrom(MapAutoresLibros));
            CreateMap<Libro, LecturaLibroDTO>();

            CreateMap<CrearComentarioDTO, Comentario>();
            CreateMap<Comentario, LecturaComentarioDTO>();

        }

        private List<AutorLibro> MapAutoresLibros(CrearLibroDTO libroDTO, Libro libro)
        {
            var resultado = new List<AutorLibro>();

            if(libroDTO.AutoresId == null) return resultado;

            foreach (var id in libroDTO.AutoresId)
            {
                resultado.Add(new AutorLibro { AutorId = id });         
            }

            return resultado;
        }
    }
}
