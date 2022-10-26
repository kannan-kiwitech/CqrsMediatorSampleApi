using Microsoft.Data.SqlClient;
using System.Data;

namespace CqrsMediatorSampleApi.Database
{
    public class ToDoContextRead
    {
        private readonly string _connectionString;

        public ToDoContextRead(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnectionRead");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}