using CqrsMediatorSampleApi.Commands;
using CqrsMediatorSampleApi.Models;
using CqrsMediatorSampleApi.Repositories;
using MediatR;

namespace CqrsMediatorSampleApi.CommandHandlers
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, bool>
    {
        private readonly IToDoRepositoryWrite _toDoRepositoryWrite;

        public UpdateToDoCommandHandler(IToDoRepositoryWrite toDoRepositoryWrite)
        {
            _toDoRepositoryWrite = toDoRepositoryWrite;
        }

        public async Task<bool> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = new ToDo
            {
                Id = request.Id,
                Description = request.Description,
                Title = request.Title,
                Created = DateTime.Now,
                IsCompleted = request.IsCompleted,
            };
            var result = await _toDoRepositoryWrite.UpdateToDo(todo);
            return result > 0;
        }
    }
}