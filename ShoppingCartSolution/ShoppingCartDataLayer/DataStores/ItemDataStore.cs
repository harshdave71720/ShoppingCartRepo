using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDataLayer.DataStores
{
    public class ItemDataStore
    {
        private IItemRepository ItemRepository;
        public ItemDataStore(IItemRepository repository) {
            this.ItemRepository = repository;
        }

        public Item Get(Item item)
        {
            return ItemRepository.Find(item);
        }

        public Item Add(Item item)
        {
            var result = ItemRepository.Add(item);
            return result;
        }

        public int IncreaseQuantity(Guid itemId, int quantity)
        {
            return ItemRepository.IncreaseQuantity(itemId, quantity);
        }

        public Item Update(Item item)
        {
            return ItemRepository.Update(item);
        }

        public Item Remove(Item item)
        {
            return ItemRepository.Remove(item);
        }

        public int DecreaseQuantity(Guid itemId, int quantity) {
            return ItemRepository.DecreaseQuantity(itemId, quantity);
        }

        public List<Item> GetAll()
        {
            return ItemRepository.GetAll().ToList() ;
        }
    }
}
