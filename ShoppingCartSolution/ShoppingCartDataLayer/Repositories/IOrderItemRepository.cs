using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDataLayer.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetAll(Guid orderId);

        void RemoveAll(Guid orderId);
    }
}
