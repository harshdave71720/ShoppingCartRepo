using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ShoppingCartLibrary;

namespace ShoppingCartEFDataLayer.DbContexts
{
    class ShoppingDbInitializer : DropCreateDatabaseIfModelChanges<ShoppingDbContext>
    {
        protected override void Seed(ShoppingDbContext context)
        {
            //base.Seed(context);
            //context.Users.Add(new User { Name = "Yash dave", Email = "yashdave111@gmail.com", Address = "Revenue colony" });

            context.Items.Add(new Item { Name = "Chair", Quantity = 3, Price = 100});
            context.Items.Add(new Item { Name = "Table", Quantity = 5, Price = 500});
            context.Items.Add(new Item { Name = "Door", Quantity = 10, Price = 300});
            context.Items.Add(new Item { Name = "Clock", Quantity = 1, Price = 50});

            context.SaveChanges();
        }
    }
}
