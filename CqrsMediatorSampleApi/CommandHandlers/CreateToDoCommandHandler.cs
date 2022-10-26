using CqrsMediatorSampleApi.Commands;
using CqrsMediatorSampleApi.Models;
using CqrsMediatorSampleApi.Repositories;
using MediatR;

namespace CqrsMediatorSampleApi.CommandHandlers
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, ToDo>
    {
        private readonly IToDoRepositoryWrite _toDoRepositoryWrite;

        public CreateToDoCommandHandler(IToDoRepositoryWrite toDoRepositoryWrite)
        {
            _toDoRepositoryWrite = toDoRepositoryWrite;
        }

        public async Task<ToDo> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = new ToDo
            {
                Created = DateTime.Now,
                Description = request.Description,
                Title = request.Title,
                Id = Guid.NewGuid(),
                IsCompleted = false
            };

            var result = await _toDoRepositoryWrite.SaveToDo(todo);
            if (result > 0)
            {
                return todo;
            }
            else
            {
                throw new ArgumentException("Unable to save the ToDo");
            }
        }
    }
}