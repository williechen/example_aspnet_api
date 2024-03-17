using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QADemo.Domain.Bases;

namespace QADemo.Domain.DbActions;

public class TableDao<T>
  where T : class
{

    private readonly RustwebdevContext _db;

    internal DbSet<T> dbSet;

    public TableDao(RustwebdevContext db)
    {
        _db = db;
        dbSet = _db.Set<T>();
    }

    public async Task<long> GetCount()
    {
        return await dbSet.CountAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        IQueryable<T> query = dbSet;
        return await query.ToListAsync();
    }

    public async Task<(long, IEnumerable<T>)> GetPage(int pageNo, int pageSize, Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (orderBy != null)
        {
            query = query.OrderBy(orderBy);
        }

        IEnumerable<T> results;
        long totleCount;
        if (pageNo > 0 && pageSize > 0)
        {
            totleCount = await query.CountAsync();
            results = await query.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToListAsync();
        }
        else
        {
            totleCount = await query.CountAsync();
            results = await query.ToListAsync();
        }
        return (totleCount, results);
    }

    public async Task<T?> GetOneAsync(int? id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<int> CreateAsync(T entity)
    {
        dbSet.Add(entity);
        return await _db.SaveChangesAsync();
    }

    public async Task<int> CreateRangeAsync(IEnumerable<T> entities)
    {
        dbSet.AddRange(entities);
        return await _db.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        dbSet.Update(entity);
        return await _db.SaveChangesAsync();
    }

    public async Task<int> UpdateRangeAsync(IEnumerable<T> entities)
    {
        dbSet.UpdateRange(entities);
        return await _db.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(T entity)
    {
        dbSet.Remove(entity);
        return await _db.SaveChangesAsync();
    }

    public async Task<int> DeleteRangeAsync(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
        return await _db.SaveChangesAsync();
    }

}