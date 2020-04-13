using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEFDataLayer.Repositories
{
    class CartItemRepository : ICartItemRepository
    {
        private ShoppingDbContext Context;
        public CartItemRepository(ShoppingDbContext dbContext) {
            this.Context = dbContext;
        }
        public CartItemRepository() : this(ShoppingDbContextFactory.GetInstance()) { 
        
        }

        public CartItem Add(CartItem obj)
        {
            var result =  Context.CartItems.Add(obj);
            Context.SaveChanges();
            return result;
        }

        public CartItem Find(CartItem Obj)
        {
            return Context.CartItems.Find(Obj.CartId, Obj.ItemId);
            //throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public CartItem Remove(CartItem obj)
        {
            CartItem cartitem = Context.CartItems.Find(obj.CartId, obj.ItemId);
            if (cartitem == null) {
                return null;
            }
            var result= Context.CartItems.Remove(obj);
            Context.SaveChanges();
            return result;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public CartItem Update(CartItem obj)
        {
            var cartItem = Context.CartItems.Find(obj.CartId, obj.ItemId);
            if (cartItem == null) {
                return null;
            }
            cartItem.Quantity = obj.Quantity;
            Context.SaveChanges();
            return cartItem;
        }

        public IEnumerable<CartItem> GetAll(Guid cartId)
        {
            return Context.CartItems.Where(ci => ci.CartId.Equals(cartId));
        }
    }
}
