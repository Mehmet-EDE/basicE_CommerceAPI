using E_Ticaret.API.Data.Data;
using E_Ticaret.API.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.API.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        private DbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new E_TicaretDbContext();
                }
                return _dbContext;
            }
            set { _dbContext = value; }
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(DbContext);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
    }

}
