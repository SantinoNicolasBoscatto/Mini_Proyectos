using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Features.ToDoTasks.Commands.UpdateToDoTaskState
{
    public class UpdateToDoTaskStateCommand : IRequest
    {
        public string? userId { get; set; }
    }
}
