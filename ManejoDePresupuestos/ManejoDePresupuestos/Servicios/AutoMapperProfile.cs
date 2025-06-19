using AutoMapper;
using ManejoDePresupuestos.Models;

namespace ManejoDePresupuestos.Servicios
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<CuentaDTO, CuentaViewModel>().ForMember(d=> d.CuentaNombre, o=> o.MapFrom(s=> s.CuentaNombre));

        }
    }
}
