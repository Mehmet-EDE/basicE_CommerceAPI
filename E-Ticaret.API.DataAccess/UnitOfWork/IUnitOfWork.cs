using E_Ticaret.API.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.API.DataAccess.UnitOfWork
{
  public interface IUnitOfWork:IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
