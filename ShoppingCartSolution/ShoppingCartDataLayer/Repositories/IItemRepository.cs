using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;

namespace ShoppingCartDataLayer.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        int IncreaseQuantity(Guid itemId, int quantity);
        int DecreaseQuantity(Guid itemId, int quantity);
    }
}
