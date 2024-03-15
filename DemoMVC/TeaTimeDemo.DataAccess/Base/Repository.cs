using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace TeaTimeDemo.DataAccess.Base {
    public class Repository<T>
      where T: class 
      {
         private readonly ApplicationDbContext _db;
         internal DbSet<T> dbSet;

         public Repository(ApplicationDbContext db){

            _db = db;
            this.dbSet = _db.Set<T>();

         }

         public int Add(T entity){
            dbSet.Add(entity);
            return _db.SaveChanges();
         }

         public T? Get(Expression<Func<T, bool>> filter){
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
         }


    }
}