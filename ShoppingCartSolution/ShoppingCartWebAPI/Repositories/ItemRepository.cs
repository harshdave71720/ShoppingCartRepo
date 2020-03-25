using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartWebAPI.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private ShoppingDbContext Db { get; set; }
        public ItemRepository(ShoppingDbContext context) {
            Db = context;
        }

        public Item Add(Item obj)
        {
            var item = Db.Items.Add(obj);
            Db.SaveChanges();
            return item;
        }

        public void Dispose()
        {
            Db.Dispose();            
        }

        public Item Find(Item Obj)
        {
            return Db.Items.Find(Obj.Id);
        }

        public Item Remove(Item obj)
        {
            var item = Db.Items.Remove(obj);
            Db.SaveChanges();
            return item;
        }

        public Item Update(Item obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
            return Db.Items.Find(obj.Id);
        }

        public IEnumerable<Item> GetAll()
        {
            return Db.Items;
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}