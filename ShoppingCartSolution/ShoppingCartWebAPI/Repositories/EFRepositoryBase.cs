using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;

namespace ShoppingCartWebAPI.Repositories
{
    public abstract class EFRepositoryBase<T>
    {
        protected ShoppingDbContext Context;
        public EFRepositoryBase(ShoppingDbContext context) {
            Context = context;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        
      
    }
}