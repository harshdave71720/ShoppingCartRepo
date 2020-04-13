using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;
using System.Runtime.Remoting.Contexts;

namespace ShoppingCartEFDataLayer.Repositories
{
    public class CartRepository : ICartRepository
    {
        private ShoppingDbContext Context;

        public CartRepository(ShoppingDbContext context) { this.Context = context; }

        public CartRepository() : this(ShoppingDbContextFactory.GetInstance()) { }

        public Cart Add(Cart obj)
        {
            var cart = Context.Carts.Add(obj);
            Context.SaveChanges();
            return cart;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Cart Find(Cart Obj)
        {
            return Context.Carts.Find(Obj.Id);
        }

        public IEnumerable<Cart> GetAll()
        {
            return Context.Carts;
        }

        public Cart Remove(Cart obj)
        {
            var cart = Context.Carts.Remove(obj);
            Context.SaveChanges();
            return cart;
        }

        public Cart Update(Cart obj)
        {
            var cart = Context.Carts.Find(obj.Id);
            cart.Status = obj.Status;
            //Context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return cart;
        }

        public IEnumerable<Cart> GetUserCarts(Guid userId)
        {
            var carts = Context.Carts.Where(c => c.UserId.Equals(userId)).ToList();
            if (carts == null) {
                return new List<Cart>();
            }
            return carts;
        }

        public IEnumerable<CartItem> GetCartItems(Guid userId, Guid cartId)
        {
            var cart = Context.Carts.SingleOrDefault(c => c.Id.Equals(cartId) && c.UserId.Equals(userId));
            if (cart == null || cart.CartItems == null || cart.CartItems.Count == 0) {
                return null;
            }

            return cart.CartItems;
        }

        public Cart GetUserCart(Guid userId, Guid cartId) {
            Cart cart = Context.Carts.SingleOrDefault(c => c.Id.Equals(cartId) && c.UserId.Equals(userId));

            return cart;
        }

        public double UpdatePrice(Guid cartId, double price) {
            var cart = Context.Carts.Find(cartId);
            if (cart == null) {
                return 0;
            }
            cart.TotalPrice = price;
            Context.SaveChanges();
            return price;
        }

        public void UpdateStatus(Guid cartId, CartStatus status)
        {
            var cart = Context.Carts.Find(cartId);
            if (cart == null) {
                throw new Exception("Cart not found");
            }
            cart.Status = status;
            Context.SaveChanges();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        //public int SaveChanges()
        //{
        //    return Db.SaveChanges();
        //}
    }
}