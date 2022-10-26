using CqrsMediatorSampleApi.Database;
using CqrsMediatorSampleApi.Models;
using Dapper;

namespace CqrsMediatorSampleApi.Repositories
{
    public class ToDoRepositoryRead : IToDoRepositoryRead
    {
        private readonly ToDoContextRead _context;

        public ToDoRepositoryRead(ToDoContextRead context)
        {
            _context = context;
        }

        public async Task<ToDo> GetToDoById(Guid id)
        {
            var query = "SELECT * FROM ToDos where id=@id";
            var param = new { id };
            using var connection = _context.CreateConnection();
            var todo = await connection.QueryFirstOrDefaultAsync<ToDo>(query, param);
            return todo;
        }

        public async Task<IEnumerable<ToDo>> GetToDos()
        {
            var query = "SELECT * FROM ToDos";
            using var connection = _context.CreateConnection();
            var todos = await connection.QueryAsync<ToDo>(query);
            return todos.ToList();
        }
    }
}