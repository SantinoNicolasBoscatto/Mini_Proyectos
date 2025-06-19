using AutoMapper;
using EFCorePeliculas.DTO;
using EFCorePeliculas.Entitys;

namespace EFCorePeliculas.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActoresDTO>();
            CreateMap<Cine, CineDTO>();
            CreateMap<Genero, GeneroDTO>();
            CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(dto => dto.CineCollection, ent => ent.MapFrom(prop => prop.SalaDeCineHash.Select(s => s.Cine)))
                .ForMember(dto => dto.ActoresCollection, ent => ent.MapFrom(prop => prop.PeliculaActorHash.Select(s=>s.Actor)));
        }
    }
}
