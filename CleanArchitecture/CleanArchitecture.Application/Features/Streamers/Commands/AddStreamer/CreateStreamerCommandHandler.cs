using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Streamers.Commands.AddStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _repository;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;
        private readonly IMapper _mapper;
        public CreateStreamerCommandHandler(IStreamerRepository repository, ILogger<CreateStreamerCommandHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer = _mapper.Map<Streamer>(request);
            var result = await _repository.AddAsync(streamer);
            _logger.LogInformation("Streamer creado con exito, Id: " + result.Id);
            return result.Id;
        }
    }
}
