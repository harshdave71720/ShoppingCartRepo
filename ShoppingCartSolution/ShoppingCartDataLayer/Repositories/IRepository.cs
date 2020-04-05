using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDataLayer.Repositories
{
    public interface IRepository<T>
    {
        T Add(T obj);

        T Remove(T obj);

        T Update(T obj);

        T Find(T Obj);

        IEnumerable<T> GetAll();

        int SaveChanges();
    }
}