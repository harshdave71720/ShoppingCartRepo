using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;

namespace ShoppingCartDataLayer.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        IEnumerable<Cart> GetUserCarts(Guid userId);

        IEnumerable<CartItem> GetCartItems(Guid userId, Guid cartId);
    }
}
