namespace QADemo.Domain.DbActions;

public interface IDbExecute<T> 
    where T: class
{
       public Task<T> GetExec(string procedureName, Dictionary<string, string> sqlParamters,int commontTimeout); 
       public Task<long> GetCount();
       public Task<IEnumerable<T>> GetAll(int commontTimeout);
       public Task<IEnumerable<T>> GetPage(int pageNo, int pageSize, string sql, string orderBy, Dictionary<string, string> sqlParamters, int commontTimeout);
       public Task<T> GetOneAsync(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       public Task<int> CreateAsync(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       public Task<int> UpdateAsync(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       public Task<int> DeleteAsync(string sql, Dictionary<string, string> sqlParamters,int commontTimeout);
       
}
