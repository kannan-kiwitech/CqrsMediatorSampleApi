using CqrsMediatorSampleApi.Models;
using MediatR;

namespace CqrsMediatorSampleApi.Commands
{
    public class GetToDoDetailQuery : IRequest<ToDo>
    {
        public Guid Id { get; set; }

        public GetToDoDetailQuery(Guid id)
        {
            Id = id;
        }

        public GetToDoDetailQuery()
        {
        }
    }
}