namespace QADemo.Domain.DbActions;

public interface IDbExecute
{
       public Task<T> GetExec<T>(string procedureName, Dictionary<string, string> sqlParamters,int commontTimeout) where T : class; 
       public Task<int> GetCount(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       public Task<IEnumerable<T>> GetAll<T>(int commontTimeout)where T : class;
       public Task<IEnumerable<T>> GetPage<T>(int pageNo, int pageSize, string sql, string orderBy, Dictionary<string, string> sqlParamters, int commontTimeout)where T : class;
       public Task<T> GetOneAsync<T>(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       public Task<int> CreateAsync(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       public Task<int> UpdateAsync(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       public Task<int> DeleteAsync(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       
}
