using CqrsMediatorSampleApi.Models;

namespace CqrsMediatorSampleApi.Repositories
{
    public interface IToDoRepositoryRead
    {
        Task<IEnumerable<ToDo>> GetToDos();

        Task<ToDo> GetToDoById(Guid id);
    }
}