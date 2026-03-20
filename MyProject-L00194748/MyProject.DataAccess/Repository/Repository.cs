using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MangaShopDBContext _dbContext;
        internal DbSet<T> dbSet;
        public Repository(MangaShopDBContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }
        public void Add(T obj)
        {
            dbSet.Add(obj);
        }
        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }
        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
        public T? Get(int id)
        {
            if (id == 0) return null;
            else return dbSet.Find(id);
        }
        
        public IEnumerable<T> GetAll(Expression<Func<T, object>>? include = null)
        {
            IQueryable<T> list = dbSet;
            if (include != null)
            {
                list = list.Include(include);
            }
            return list.ToList();
        }
    }
}
