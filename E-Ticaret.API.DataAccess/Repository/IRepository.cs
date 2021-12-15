using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Ticaret.API.DataAccess.Repository
{
   public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        List<T> GetAll();
    }
}
