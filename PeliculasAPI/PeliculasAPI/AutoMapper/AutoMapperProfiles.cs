using AutoMapper;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, LecturaGeneroDTO>().ReverseMap();
            CreateMap<CrearGeneroDTO, Genero>();

            CreateMap<Actor, LecturaActoresDTO>().ReverseMap();
            CreateMap<CrearActorDTO, Actor>().ForMember(x => x.Foto, dest => dest.Ignore());

            CreateMap<Pelicula, LecturaPeliculaDTO>().ReverseMap();
            CreateMap<CrearPeliculaDTO, Pelicula>()
                .ForMember(x => x.Poster, dest => dest.Ignore())
                .ForMember(x => x.ListActores, dest => dest.MapFrom(MapearActoresPeliculas))
                .ForMember(x => x.ListGeneros, dest => dest.MapFrom(MapearGenerosPeliculas));

            CreateMap<SalasDeCine, LecturaSalaDeCineDTO>()
                .ForMember(x => x.Latitud, dest => dest.MapFrom(y => y.Ubicacion.Y))
                .ForMember(x => x.Longitud, dest => dest.MapFrom(y => y.Ubicacion.X));

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            CreateMap<LecturaSalaDeCineDTO, SalasDeCine>()
                .ForMember(x => x.Ubicacion, dest => dest
                .MapFrom(y => geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));

            CreateMap<CrearSalaDeCineDTO, SalasDeCine>()
                .ForMember(x => x.Ubicacion, dest => dest
                .MapFrom(y => geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));
        }

        private List<ActoresPeliculas> MapearActoresPeliculas(CrearPeliculaDTO DTO, Pelicula pelicula)
        {
            var list = new List<ActoresPeliculas>();
            if (DTO.ListActores == null) return list;
            foreach (var item in DTO.ListActores)
            {
                list.Add(new ActoresPeliculas { ActorId = item.ActorId, Personaje = item.Personaje! });
            }
            return list;
        }

        private List<GenerosPeliculas> MapearGenerosPeliculas(CrearPeliculaDTO DTO, Pelicula pelicula)
        {
            var list = new List<GenerosPeliculas>();
            if (DTO.ListaGenerosIds == null) return list;
            foreach (var item in DTO.ListaGenerosIds)
            {
                list.Add(new GenerosPeliculas { GeneroId = item });
            }
            return list;
        }

    }
}
