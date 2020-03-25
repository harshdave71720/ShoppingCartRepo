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

                //Console.WriteLine(Guid.NewGuid().ToString());
                //Console.WriteLine(Guid.NewGuid().ToString());

                context.Users.RemoveRange(context.Users);
                context.Orders.RemoveRange(context.Orders);
                context.CartItems.RemoveRange(context.CartItems);
                context.Items.RemoveRange(context.Items);

                //User harsh = new User { Name = "harsh", Carts = new List<Cart>() };
                ////User harsh1 = new User { Name = "harsh", Carts = new List<Cart>() };
                ////context.Users.Add(harsh);
                //Cart cart = new Cart {User = harsh, CartItems = new List<CartItem>() };
                ////Cart cart2 = new Cart { Id = "Cart2", User = new User { Id = "osme"}, CartItems = new List<CartItem>() };
                ////harsh.Carts.Add(cart);
                //context.Carts.Add(cart);
                //context.Carts.Add(cart);
                //context.Carts.Add(cart);
                //context.Carts.Add(cart);
                //Item item = new Item();
                //context.Items.Add(item);
                //cart.CartItems.Add(new CartItem { Cart = cart, Item = item});
                //cart.CartItems.Add(new CartItem { Cart = cart, Item = new Item() });

                ////context.Carts.Add(cart2);
                ////context.SaveChanges();

                ////context.Users.Add(harsh);
                //context.SaveChanges();
                //Console.WriteLine(item.Id.ToString().Equals(cart.CartItems.Last().Item.Id));
                //foreach (var ci in cart.CartItems) {
                //    Console.WriteLine(ci.Cart.Id.ToString() + "\t" + ci.Item.Id.ToString());
                //    Console.WriteLine(ci.Cart.Id.ToString().Equals(ci.Item.Id.ToString()));
                //}

                //context.Carts.Single(c => c.Id.Equals(cart.Id)).CartItems.Single(ci => ci.Item.Id.Equals(item.Id)).Quantity++;

                for (int i = 0; i < 5; i++) {
                    context.Users.Add(new User { Name = "user" + i, Carts = new List<Cart>()});
                    
                }
                
                context.SaveChanges();
                for (int i = 0; i < 5; i++)
                {
                    //context.Carts.Add(new Cart
                    //{
                    //    TotalPrice = i,
                    //    User = context.Users.First()
                    //,
                    //    CartItems = new List<CartItem>()
                    //});
                }
                
                context.SaveChanges();
            }

            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
