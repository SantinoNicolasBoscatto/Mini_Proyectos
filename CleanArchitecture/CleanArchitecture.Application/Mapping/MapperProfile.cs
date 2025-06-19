using AutoMapper;
using CleanArchitecture.Application.Features.Director.Commands.CreateDirector;
using CleanArchitecture.Application.Features.Streamers.Commands.AddStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Features.Videos.Commands.CreateVideo;
using CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<CreateDirectorCommand, Director>();
            CreateMap<CreateVideoCommand, Video>();

            CreateMap<UpdateStreamerCommand, Streamer>();
        }
    }
}
