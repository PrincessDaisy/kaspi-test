using Dapper;
using Repository.Context;

namespace DapperRepository.Database
{
    public class DapperDatabase 
    {
        private readonly DapperContext _context;

        public DapperDatabase(DapperContext context)
        {
            _context = context;
        }

        public void CtreateDatabase(string dbName)
        {
            try
            {
                var query = "SELECT * FROM sys.databases WHERE name = @name";
                var parameters = new DynamicParameters();
                parameters.Add("name", dbName);

                using (var connection = _context.CreateMasterConnection())
                {
                    var records = connection.Query(query, parameters);

                    if (!records.Any())
                        connection.Execute($"CREATE DATABASE {dbName}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
