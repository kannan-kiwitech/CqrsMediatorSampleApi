using CqrsMediatorSampleApi.Commands;
using CqrsMediatorSampleApi.Models;
using CqrsMediatorSampleApi.Repositories;
using MediatR;

namespace CqrsMediatorSampleApi.QueryHandlers
{
    public class GetAllToDosQueryHandler : IRequestHandler<GetAllToDosQuery, IEnumerable<ToDo>>
    {
        private readonly IToDoRepositoryRead _toDoRepositoryRead;

        public GetAllToDosQueryHandler(IToDoRepositoryRead toDoRepositoryRead)
        {
            _toDoRepositoryRead = toDoRepositoryRead;
        }

        public async Task<IEnumerable<ToDo>> Handle(GetAllToDosQuery request, CancellationToken cancellationToken)
        {
            return await _toDoRepositoryRead.GetToDos();
        }
    }
}