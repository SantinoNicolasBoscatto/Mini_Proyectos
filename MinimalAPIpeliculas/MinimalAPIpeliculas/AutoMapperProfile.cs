using AutoMapper;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Entitys;

namespace MinimalAPIpeliculas
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<CrearGeneroDTO, Genero> ();
            CreateMap<Genero, LecturaGeneroDTO> ();
            CreateMap<CrearActorDTO, Actor>()
                .ForMember(x => x.Foto, y => y.Ignore());
            CreateMap<Actor, LecturaActoresDTO> ();
            CreateMap<CrearPeliculaDTO, Pelicula>()
                .ForMember(x => x.Poster, y => y.Ignore());

            CreateMap<Pelicula, LecturaPeliculaDTO>()
                .ForMember(x => x.ListaLecturaGenero, entidad =>
                entidad.MapFrom(p => p.ListaGenerosPeliculas.Select(gp =>
                new LecturaGeneroDTO { Id = gp.GeneroId, Nombre = gp.Genero.Nombre })))
                .ForMember(x => x.ListaLecturaActor, entidad => entidad.MapFrom(p => p.ListaPeliculaActor.Select(gp =>
                new ActorPeliculaDTO { Id = gp.ActorId, Nombre = gp.Actor.Nombre, Personaje = gp.Personaje })));

            CreateMap<CrearComentarioDTO, Comentario>();
            CreateMap<Comentario, LecturaComentarioDTO>();


            CreateMap<AsignarActorPeliculaDTO, ActoresPeliculas>();
        }
    }
}
