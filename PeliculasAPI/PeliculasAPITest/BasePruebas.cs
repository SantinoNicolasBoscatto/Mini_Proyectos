using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI;
using PeliculasAPI.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPITest
{
    public class BasePruebas
    {
        protected Negocio ConstruirContext(string nombreBD)
        {
            var opt = new DbContextOptionsBuilder<Negocio>()
                      .UseInMemoryDatabase(nombreBD).Options;
            return new Negocio(opt);
        }

        protected IMapper ConfigurarMapper()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapperProfiles());
            });
            return config.CreateMapper();
        }

    }
}
