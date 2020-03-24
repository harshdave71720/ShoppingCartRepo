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
                context.Users.RemoveRange(context.Users);
                context.Orders.RemoveRange(context.Orders);
                context.CartItems.RemoveRange(context.CartItems);
                context.Items.RemoveRange(context.Items);

                User harsh = new User { Id = "user11", Name = "harsh", Carts = new List<Cart>() };
                //context.Users.Add(harsh);
                Cart cart = new Cart { Id = "Cart1", User = harsh, CartItems = new List<CartItem>() };
                //Cart cart2 = new Cart { Id = "Cart2", User = new User { Id = "osme"}, CartItems = new List<CartItem>() };
                //harsh.Carts.Add(cart);
                context.Carts.Add(cart);
                Item item = new Item { Id = "item1" };
                context.Items.Add(item);
                cart.CartItems.Add(new CartItem { Cart = cart, Item = item});
                cart.CartItems.Add(new CartItem { Cart = cart, Item = new Item { Id = "item224"} });
                
                //context.Carts.Add(cart2);
                //context.SaveChanges();
                
                //context.Users.Add(harsh);
                context.SaveChanges();

                context.Carts.Single(c => c.Id == "Cart1").CartItems.Single(ci => ci.Item.Id == item.Id).Quantity++;

                context.SaveChanges();
            }

            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
