
using Microsoft.Extensions.Logging;
using QADemo.Domain.Bases;

namespace QADemo.Domain.DbActions.DbExecutes{

public class DbObjDapper : IDbExecute
{

    private readonly ILogger _logger;
    private readonly RustwebdevContext _db;

    public DbObjDapper(ILogger logger, RustwebdevContext db)
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

        public Task<int> GetCount(string sql, Dictionary<string, string> sqlParamters, int commontTimeout)
        {
            throw new NotImplementedException();
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
