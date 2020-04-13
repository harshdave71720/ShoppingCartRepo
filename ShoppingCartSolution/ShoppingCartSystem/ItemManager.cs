using ShoppingCartDataLayer.DataStores;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartSystem
{
    public class ItemManager
    {
        private ItemDataStore ItemStore;
        public ItemManager(ItemDataStore store) {
            this.ItemStore = store;
        }

        public Item AddItem(Item item)
        {
            return ItemStore.Add(item);
        }

        public Item GetItem(Guid id)
        {
            return ItemStore.Get(new Item { Id = id });
        }

        public Item UpdateItem(Item item)
        {
            return ItemStore.Update(item);
        }

        public Item RemoveItem(Guid id)
        {
            return ItemStore.Remove(new Item { Id = id });
        }

        //public CartItem AddItemToCart(Guid userId, Guid itemId, int Qunatity)
        //{
        //    var user = DataSource.Users.Find(new User { Id = userId });
        //    //temporary user check
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    //permanent code
        //    var item = DataSource.Items.Find(new Item { Id = itemId });
        //    if (item == null)
        //    {
        //        return null;
        //    }
        //    int quantity = user.GetActiveCart().Add(item, Qunatity);
        //    DataSource.SaveChanges();
        //    return new CartItem() { Item = item, ItemId = item.Id, Quantity = Qunatity };
        //}

        public List<Item> GetItems() {
            return ItemStore.GetAll().ToList();
        }

        public int InCreaseItemQuantity(Guid itemId, int quantity) {
            if (quantity <= 0) {
                throw new InvalidOperationException("cannot add 0  or negative qunatity to item");
            }
            return ItemStore.IncreaseQuantity(itemId, quantity);
        }

        public int DecreaseItemQuantity(Guid itemId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("cannot remove 0  or negative qunatity to item");
            }
          
            return ItemStore.DecreaseQuantity(itemId, quantity);
        }
    }
}
