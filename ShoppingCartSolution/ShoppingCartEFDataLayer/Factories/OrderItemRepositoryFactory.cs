using ShoppingCartDataLayer.Factories;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEFDataLayer.Factories
{
    public class OrderItemRepositoryFactory : IRepositoryFactory<IOrderItemRepository>
    {
        public IOrderItemRepository GetInstance()
        {
            return new OrderItemRepository();
        }
    }
}
