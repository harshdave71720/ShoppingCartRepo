using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    class ItemErrorMessage
    {
        public Item Item;
        public string Message { get; private set; }
        public int RequiredQuantity;
        public int AvailableQuantity;
        public ItemErrorMessage(Item item, int required, int available) {
            this.Item = item;
            RequiredQuantity = required;
            AvailableQuantity = available;
            Message = string.Format("Item Name : {0}, Required Quantity : {1}, Available Quantity : {2}",
                item.Name, RequiredQuantity, AvailableQuantity);
        }
    }
}
