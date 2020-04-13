using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDataLayer.Factories;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.Repositories;

namespace ShoppingCartEFDataLayer.Factories
{
    public class CartRepositoryFactory : ICartRepositoryFactory
    {
        public ICartRepository GetInstance()
        {
            return new CartRepository();
        }
    }
}
