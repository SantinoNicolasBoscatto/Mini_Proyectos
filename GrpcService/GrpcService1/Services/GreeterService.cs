using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class BeersService : Beers.BeersBase
    {
        private readonly ILogger<BeersService> _logger;
        public BeersService(ILogger<BeersService> logger)
        {
            _logger = logger;
        }

        // ServerCallContext tendra informacion sobre el contexto del servicio (Dominio, Puerto)
        public override Task<BeersReply> GetBeers(BeersRequest request, ServerCallContext context)
        {
            var reply = new BeersReply();
            reply.Beers.AddRange(new List<string>()
            {
                "A", "B", "C"
            });
            return Task.FromResult(reply);
        }
    }
}
