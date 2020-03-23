using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;

namespace ShoppingCartEfConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ShoppingDbContext context = new ShoppingDbContext("ShoppingCartDatabase")) {
                context.Users.Add(new User { Id = "user11", Name = "harsh"});

                context.SaveChanges();
            }

            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
