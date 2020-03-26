using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
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
