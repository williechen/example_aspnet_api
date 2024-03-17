using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using QADemo.Domain.Bases;

namespace QADemo.Domain.DbActions.DbExecutes{

public class DbRawExecute : IDbExecute
{
    private readonly ILogger _logger;
    private readonly RustwebdevContext _db;

    public DbRawExecute(ILogger logger, RustwebdevContext db)
    {
        _logger = logger;
        _db = db;
    }

        public Task<int> CreateAsync(string sql, Dictionary<string, string> sqlParamters, int commontTimeout)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(string sql, Dictionary<string, string> sqlParamters, int commontTimeout)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll<T>(int commontTimeout) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCount(string sql, Dictionary<string, string> sqlParamters, int commontTimeout)
    {
        int count = 0;
        await using (NpgsqlConnection conn = new NpgsqlConnection(_db.Database.GetConnectionString()))
        {

            conn.Open();

            using (var cmd = new NpgsqlCommand($"SELECT COUNT(1) AS CNT FROM ({sql})", conn))
            {
                if (sqlParamters != null)
                {
                    foreach (string key in sqlParamters.Keys)
                    {
                        if (sqlParamters.GetValueOrDefault(key) != null)
                        {
                            cmd.Parameters.AddWithValue(key, sqlParamters.GetValueOrDefault(key)!);
                        }
                    }
                }

                var dr = cmd.ExecuteReader();

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetName(i));
                }

                dr.Read();
                count = dr.GetInt32(0);
                dr.Close();
            }
        }
        return count;
    }

        public Task<T> GetExec<T>(string procedureName, Dictionary<string, string> sqlParamters, int commontTimeout) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetOneAsync<T>(string sql, Dictionary<string, string> sqlParamters, int commontTimeout)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetPage<T>(int pageNo, int pageSize, string sql, string orderBy, Dictionary<string, string> sqlParamters, int commontTimeout) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(string sql, Dictionary<string, string> sqlParamters, int commontTimeout)
        {
            throw new NotImplementedException();
        }
    }
}