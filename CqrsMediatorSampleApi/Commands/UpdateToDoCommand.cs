using MediatR;

namespace CqrsMediatorSampleApi.Commands
{
    public class UpdateToDoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }

        public UpdateToDoCommand(Guid id, string? title, string? description, bool isCompleted)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            Id = id;
        }

        public UpdateToDoCommand()
        {
        }
    }
}