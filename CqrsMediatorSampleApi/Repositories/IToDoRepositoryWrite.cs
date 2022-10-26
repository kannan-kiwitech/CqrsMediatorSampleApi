using CqrsMediatorSampleApi.Models;

namespace CqrsMediatorSampleApi.Repositories
{
    public interface IToDoRepositoryWrite
    {
        Task<int> SaveToDo(ToDo toDo);

        Task<int> UpdateToDo(ToDo toDo);

        Task<int> DeleteToDoById(Guid id);
    }
}