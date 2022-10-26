using CqrsMediatorSampleApi.Models;
using MediatR;

namespace CqrsMediatorSampleApi.Commands
{
    public class GetAllToDosQuery : IRequest<IEnumerable<ToDo>>
    {
    }
}