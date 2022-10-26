using Microsoft.Data.SqlClient;
using System.Data;

namespace CqrsMediatorSampleApi.Database
{
    public class ToDoContextWrite
    {
        private readonly string _connectionString;

        public ToDoContextWrite(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnectionWrite");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}