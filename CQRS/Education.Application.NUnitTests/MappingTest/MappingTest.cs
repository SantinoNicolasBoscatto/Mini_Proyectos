using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.MappingTest
{
    public class MappingTest : Profile
    {
        public MappingTest() 
        { 
            CreateMap<Curso, CursoDTO>();
        }
    }
}
