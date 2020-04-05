using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;


namespace ShoppingCartWebAPI.Repositories
{
    public class CartRepository : EFRepositoryBase<Cart>,IRepository<Cart>
    {
        private ShoppingDbContext Db { get; set; }
        public CartRepository(ShoppingDbContext context) : base(context){
            Db = context;
        }

        public Cart Add(Cart obj)
        {
            var cart = Db.Carts.Add(obj);
            Db.SaveChanges();
            return cart;
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public Cart Find(Cart Obj)
        {
            return Db.Carts.Find(Obj.Id);
        }

        public IEnumerable<Cart> GetAll()
        {
            return Db.Carts;
        }

        public Cart Remove(Cart obj)
        {
            var cart = Db.Carts.Remove(obj);
            Db.SaveChanges();
            return cart;
        }

        public Cart Update(Cart obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
            return Db.Carts.Find(obj);
        }

        //public int SaveChanges()
        //{
        //    return Db.SaveChanges();
        //}
    }
}