using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IStreamerRepository repository;
        public DeleteStreamerCommandHandler(IStreamerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerDelete = await repository.GetByIdAsync(request.Id);
            if (streamerDelete == null) throw new NotFoundException(nameof(Streamer), request);
            await repository.DeleteAsync(streamerDelete);

            return Unit.Value;
        }
    }
}
