using Microsoft.EntityFrameworkCore;
using Npgsql;
using QADemo.Domain.Bases;

namespace QADemo;

public class DBRawExecute
{
    private readonly ILogger<DBRawExecute> _logger;
    private readonly RustwebdevContext _db;

    public DBRawExecute(ILogger<DBRawExecute> logger, RustwebdevContext db)
    {
        _logger = logger;
        _db = db;
    }

    public async Task<long> GetCount(string sql, Dictionary<string, object>? parameters)
    {
        long count = 0;
        await using (NpgsqlConnection conn = new NpgsqlConnection(_db.Database.GetConnectionString()))
        {

            conn.Open();

            using (var cmd = new NpgsqlCommand($"SELECT COUNT(1) AS CNT FROM ({sql})", conn))
            {
                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                    {
                        if (parameters.GetValueOrDefault(key) != null)
                        {
                            cmd.Parameters.AddWithValue(key, parameters.GetValueOrDefault(key)!);
                        }
                    }
                }

                var dr = cmd.ExecuteReader();

                for(int i=0;i<dr.FieldCount;i++)
                {
                    Console.WriteLine(dr.GetName(i));
                }

                dr.Read();
                count = dr.GetInt64(0);
                dr.Close();
            }
        }
        return count;
    }

}