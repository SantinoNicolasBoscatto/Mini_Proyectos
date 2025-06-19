using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        public UpdateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerBD = await _streamerRepository.GetByIdAsync(request.Id);
            if (streamerBD == null) throw new NotFoundException(nameof(Streamer), request);

            // Otra forma de usar el mapper es definir los Types que estoy seteando.
            _mapper.Map(request, streamerBD, typeof(UpdateStreamerCommand), typeof(Streamer));
            await _streamerRepository.UpdateAsync(streamerBD);
            return Unit.Value;
        }
    }


}
