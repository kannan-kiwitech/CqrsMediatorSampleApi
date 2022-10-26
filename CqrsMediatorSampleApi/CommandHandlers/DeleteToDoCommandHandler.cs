using CqrsMediatorSampleApi.Commands;
using CqrsMediatorSampleApi.Repositories;
using MediatR;

namespace CqrsMediatorSampleApi.CommandHandlers
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand, bool>
    {
        private readonly IToDoRepositoryWrite _toDoRepositoryWrite;

        public DeleteToDoCommandHandler(IToDoRepositoryWrite toDoRepositoryWrite)
        {
            _toDoRepositoryWrite = toDoRepositoryWrite;
        }

        public async Task<bool> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var result = await _toDoRepositoryWrite.DeleteToDoById(request.Id);
            return result > 0;
        }
    }
}