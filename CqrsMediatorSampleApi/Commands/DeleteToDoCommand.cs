using MediatR;

namespace CqrsMediatorSampleApi.Commands
{
    public class DeleteToDoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteToDoCommand(Guid id)
        {
            Id = id;
        }

        public DeleteToDoCommand()
        {
        }
    }
}