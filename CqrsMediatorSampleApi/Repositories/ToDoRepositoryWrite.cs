using CqrsMediatorSampleApi.Database;
using CqrsMediatorSampleApi.Models;
using Dapper;

namespace CqrsMediatorSampleApi.Repositories
{
    public class ToDoRepositoryWrite : IToDoRepositoryWrite
    {
        private readonly ToDoContextWrite _context;

        public ToDoRepositoryWrite(ToDoContextWrite context)
        {
            _context = context;
        }

        public async Task<int> DeleteToDoById(Guid id)
        {
            var query = "DELETE FROM ToDos where id=@id";
            var param = new { id };
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, param);
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

        public async Task<int> SaveToDo(ToDo toDo)
        {
            var query = @"INSERT INTO ToDos
                        (Id, Title, Description, Created, IsCompleted)
                        VALUES (@Id, @Title, @Description, @Created, @IsCompleted);";
            toDo.Created = DateTime.Now;
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, toDo);
        }

        public async Task<int> UpdateToDo(ToDo toDo)
        {
            var query = @"UPDATE ToDos SET
                        Title=@Title, Description=@Description, Created=@Created, IsCompleted=@IsCompleted
                        WHERE Id=@Id";
            toDo.Created = DateTime.Now;
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, toDo);
        }
    }
}