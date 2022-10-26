using CqrsMediatorSampleApi.Commands;
using CqrsMediatorSampleApi.Models;
using CqrsMediatorSampleApi.Repositories;
using MediatR;

namespace CqrsMediatorSampleApi.QueryHandlers
{
    public class GetToDoDetailQueryHandler : IRequestHandler<GetToDoDetailQuery, ToDo>
    {
        private readonly IToDoRepositoryRead _toDoRepositoryRead;

        public GetToDoDetailQueryHandler(IToDoRepositoryRead toDoRepositoryRead)
        {
            _toDoRepositoryRead = toDoRepositoryRead;
        }

        public async Task<ToDo> Handle(GetToDoDetailQuery request, CancellationToken cancellationToken)
        {
            return await _toDoRepositoryRead.GetToDoById(request.Id);
        }
    }
}