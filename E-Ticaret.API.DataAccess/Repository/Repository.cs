using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Ticaret.API.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext DbContext;
        private readonly DbSet<T> DbSet;
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();

        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Update(T entity)
        {
                DbSet.Attach(entity);
                DbContext.Entry(entity).State= EntityState.Modified;
            }
    }
}
