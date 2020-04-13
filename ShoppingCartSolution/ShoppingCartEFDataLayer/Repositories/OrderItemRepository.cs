using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDataLayer;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;
using ShoppingCartLibrary;

namespace ShoppingCartEFDataLayer.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private ShoppingDbContext Context;
        public OrderItemRepository(ShoppingDbContext dbContext)
        {
            this.Context = dbContext;
        }
        public OrderItemRepository() : this(ShoppingDbContextFactory.GetInstance()) { 
        
        }
        public OrderItem Add(OrderItem obj)
        {
            var result =  Context.OrderItems.Add(obj);
            Context.SaveChanges();
            return result;
        }

        public OrderItem Find(OrderItem Obj)
        {
            //throw new NotImplementedException();
            return Context.OrderItems.Find(Obj.OrderId, Obj.ItemId);
        }

        public IEnumerable<OrderItem> GetAll(Guid orderId)
        {
            return Context.OrderItems.Where(oi => oi.OrderId.Equals(orderId));
        }

        public IEnumerable<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderItem Remove(OrderItem obj)
        {
            var orderItem = Context.OrderItems.Find(obj.OrderId, obj.ItemId);
            if (orderItem == null) {
                return null;
            }
            return Context.OrderItems.Remove(obj);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public OrderItem Update(OrderItem obj)
        {
            var orderItem = Context.OrderItems.Find(obj.OrderId, obj.ItemId);
            if (orderItem == null)
            {
                return null;
            }
            orderItem.Quantity = obj.Quantity;
            Context.SaveChanges();
            return orderItem;
        }

        public void RemoveAll(Guid orderId)
        {
            var orderITems = Context.OrderItems.RemoveRange(Context.OrderItems.Where(oi => oi.OrderId.Equals(orderId)));
            Context.SaveChanges();
        }

        //public IEnumerable<OrderItem> GetAll(Guid orderId)
        //{
        //    return Context.OrderItems.Where(oi => oi.OrderId.Equals(orderId));
        //}
    }
}
