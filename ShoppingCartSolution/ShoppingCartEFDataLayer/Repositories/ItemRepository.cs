using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;

namespace ShoppingCartEFDataLayer.Repositories
{
    public class ItemRepository : EFRepositoryBase<Item>,IItemRepository
    {
        public ItemRepository(ShoppingDbContext context) : base(context){
            
        }

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
            if (Context.Items.Find(obj) == null) {
                return null;
            }
            Context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return Context.Items.Find(obj.Id);
        }

        public IEnumerable<Item> GetAll()
        {
            return Context.Items;
        }

        //public int SaveChanges()
        //{
        //    return Db.SaveChanges();
        //}
    }
}