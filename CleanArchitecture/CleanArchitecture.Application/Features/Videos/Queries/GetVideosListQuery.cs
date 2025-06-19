using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries
{
    // Esta clase sera la encargada de pedir parametros al usuario, basicamente cargaremos la data que nos manda el usuario
    public class GetVideosListQuery : IRequest<List<Video>>
    {
        public GetVideosListQuery(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
        public string? Username { get; set; }
    }
}
