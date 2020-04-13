using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;

namespace ShoppingCartEFDataLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private ShoppingDbContext Context;
        public ItemRepository(ShoppingDbContext context) { this.Context = context; }
        public ItemRepository() : this(ShoppingDbContextFactory.GetInstance()){ }

        public Item Add(Item obj)
        {
            var item = Context.Items.Add(obj);
            Context.SaveChanges();
            return item;
        }

        public void Dispose()
        {
            Context.Dispose();            
        }

        public Item Find(Item Obj)
        {
            return Context.Items.Find(Obj.Id);
        }

        public Item Remove(Item obj)
        {
            var item = Find(obj);
            if (item == null) {
                return null;
            }
            var item2 = Context.Items.Remove(item);
            Context.SaveChanges();
            return item2;
        }

        public Item Update(Item obj)
        {
            var item = Context.Items.Find(obj);
            if (item == null) {
                return null;
            }
            if (!string.IsNullOrWhiteSpace(obj.Name)) {
                item.Name = obj.Name;
            }
            Context.SaveChanges();
            return Context.Items.Find(obj.Id);
        }

        public IEnumerable<Item> GetAll()
        {
            return Context.Items;
        }

        public int IncreaseQuantity(Guid itemId, int quantity)
        {
            var item = Context.Items.Find(itemId);
            if (item == null) {
                return -1;
            }
            item.Quantity += quantity;
            Context.SaveChanges();
            return item.Quantity;
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public int DecreaseQuantity(Guid itemId, int quantity)
        {
            var item = Context.Items.Find(itemId);
            if (item == null) {
                return -1;
            }
            if (quantity > item.Quantity) {
                throw new InvalidOperationException("Cannot decrease item quantity as it is not sufficiently present");
            }
            item.Quantity -= quantity;
            Context.SaveChanges();
            return item.Quantity;
        }

        //public int SaveChanges()
        //{
        //    return Db.SaveChanges();
        //}
    }
}