using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;

namespace ShoppingCartWebAPI.Repositories
{
    public class OrderRepository : EFRepositoryBase<Order>, IRepository<Order>
    {
        public OrderRepository(ShoppingDbContext context) : base(context) { }
        public Order Add(Order obj)
        {
            var order = Context.Orders.Add(obj);
            Context.SaveChanges();
            return order;
        }

        public Order Find(Order Obj)
        {
            return Context.Orders.Find(Obj.Id);
        }

        public IEnumerable<Order> GetAll()
        {
            return Context.Orders;
        }

        public Order Remove(Order obj)
        {
            var order = Context.Orders.Remove(obj);
            Context.SaveChanges();
            return order;
        }

        public Order Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}