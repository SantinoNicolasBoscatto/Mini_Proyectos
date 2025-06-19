using MediatR;
using NotesApp.Application.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Commands.UpdateToDoTaskState
{
    public class UpdateToDoTaskStateCommandHandler : IRequestHandler<UpdateToDoTaskStateCommand>
    {
        private readonly IUnitOfWork _toDoTaskRepo;
        public UpdateToDoTaskStateCommandHandler(IUnitOfWork toDoTaskRepo)
        {
            _toDoTaskRepo = toDoTaskRepo;
        }

        public async Task<Unit> Handle(UpdateToDoTaskStateCommand request, CancellationToken cancellationToken)
        {
            await _toDoTaskRepo.ToDoTaskRepository.UpdateToDoState(request.userId!);
            await _toDoTaskRepo.Complete();
            return Unit.Value;
        }
    }
}
