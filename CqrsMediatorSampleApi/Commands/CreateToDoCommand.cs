using CqrsMediatorSampleApi.Models;
using MediatR;

namespace CqrsMediatorSampleApi.Commands
{
    public class CreateToDoCommand : IRequest<ToDo>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public CreateToDoCommand(string? title, string? description)
        {
            Title = title;
            Description = description;
        }

        public CreateToDoCommand()
        {
        }
    }
}