using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;

namespace ShoppingCartEFDataLayer.Repositories
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