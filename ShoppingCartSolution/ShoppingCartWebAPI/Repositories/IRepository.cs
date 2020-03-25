using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartWebAPI.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        T Add(T obj);

        T Remove(T obj);

        T Update(T obj);

        T Find(T Obj);

        IEnumerable<T> GetAll();

        int SaveChanges();
    }
}