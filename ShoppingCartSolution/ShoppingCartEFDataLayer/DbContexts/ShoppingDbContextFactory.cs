using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;

namespace ShoppingCartEFDataLayer.DbContexts
{
    public class ShoppingDbContextFactory
    {
        private static ShoppingDbContext context;

        public static ShoppingDbContext GetInstance() {
            if (context == null) {
                context = new ShoppingDbContext("ShoppingCartDatabase");
            }
            return context;
        }
    }
}
