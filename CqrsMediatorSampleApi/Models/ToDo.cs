namespace CqrsMediatorSampleApi.Models
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}