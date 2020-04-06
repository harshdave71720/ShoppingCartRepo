using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartSystem
{
    public class ItemManager : ShoppingSystemManager
    {
        public ItemManager(IDataSource dataSource) : base(dataSource) { }

        public Item AddItem(Item item)
        {
            return DataSource.Items.Add(item);
        }

        public Item GetItem(Guid id)
        {
            return DataSource.Items.Find(new Item { Id = id });
        }

        public Item UpdateItem(Item item)
        {
            return DataSource.Items.Update(item);
        }

        public Item RemoveItem(Guid id)
        {
            return DataSource.Items.Remove(new Item { Id = id });
        }

        public CartItem AddItemToCart(Guid userId, Guid itemId, int Qunatity)
        {
            var user = DataSource.Users.Find(new User { Id = userId });
            //temporary user check
            if (user == null)
            {
                return null;
            }
            //permanent code
            var item = DataSource.Items.Find(new Item { Id = itemId });
            if (item == null)
            {
                return null;
            }
            int quantity = user.GetActiveCart().Add(item, Qunatity);
            DataSource.SaveChanges();
            return new CartItem() { Item = item, ItemId = item.Id, Quantity = Qunatity };
        }
    }
}
