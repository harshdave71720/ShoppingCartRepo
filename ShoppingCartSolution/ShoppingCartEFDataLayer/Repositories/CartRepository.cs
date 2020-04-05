using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;

namespace ShoppingCartEFDataLayer.Repositories
{
    public class CartRepository : EFRepositoryBase<Cart>,ICartRepository
    {
        public CartRepository(ShoppingDbContext context) : base(context){
            
        }

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
            Context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return Context.Carts.Find(obj);
        }

        public IEnumerable<Cart> GetUserCarts(Guid userId)
        {
            var carts = Context.Carts.Where(c => c.User.Id.Equals(userId)).ToList();
            if (carts == null || carts.Count == 0) {
                return null;
            }
            return carts;
        }

        public IEnumerable<CartItem> GetCartItems(Guid userId, Guid cartId)
        {
            var cart = Context.Carts.SingleOrDefault(c => c.Id.Equals(cartId) && c.User.Id.Equals(userId));
            if (cart == null || cart.CartItems == null || cart.CartItems.Count == 0) {
                return null;
            }

            return cart.CartItems;
        }

        //public int SaveChanges()
        //{
        //    return Db.SaveChanges();
        //}
    }
}