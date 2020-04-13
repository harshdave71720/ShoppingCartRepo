using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDataLayer.DataStores;
using ShoppingCartDataLayer.Factories;
using ShoppingCartDataLayer.Repositories;


namespace ShoppingCartDataLayer.Factories
{
    public class DataStoreFactory
    {
        private static IRepositoryFactory<IItemRepository> ItemRepositoryFactory;
        private static IRepositoryFactory<IUserRepository> UserRepositoryFactory;
        private static IRepositoryFactory<ICartRepository> CartRepositoryFactory;
        private static IRepositoryFactory<IOrderRepository> OrderRepositoryFactory;
        private static IRepositoryFactory<ICartItemRepository> CartItemRepositoryFactory;
        private static IRepositoryFactory<IOrderItemRepository> OrderItemRepositoryFactory;

        public static void Initialize(IRepositoryFactory<IItemRepository> itemRepositoryFactory = null,
            IRepositoryFactory<IOrderRepository> orderRepositoryFactory = null,
            IRepositoryFactory<IUserRepository> userRepositoryFactory = null,
            IRepositoryFactory<ICartRepository> cartRepositoryFactory = null,
            IRepositoryFactory<ICartItemRepository> cartItemRepositoryFactory = null,
            IRepositoryFactory<IOrderItemRepository> orderItemRepositoryFactory = null) {
            
            ItemRepositoryFactory = itemRepositoryFactory;
            UserRepositoryFactory = userRepositoryFactory;
            CartRepositoryFactory = cartRepositoryFactory;
            OrderRepositoryFactory = orderRepositoryFactory;
            OrderItemRepositoryFactory = orderItemRepositoryFactory;
            CartItemRepositoryFactory = cartItemRepositoryFactory;
        }

        public static UserDataStore CreateUserDataStore() {
            return new UserDataStore(UserRepositoryFactory.GetInstance());
        }

        public static CartDataStore CreateCartDataStore() {
            return new CartDataStore(CartRepositoryFactory.GetInstance(), CartItemRepositoryFactory.GetInstance());
        }

        public static ItemDataStore CreateItemDataStore() {
            return new ItemDataStore(ItemRepositoryFactory.GetInstance());
        }

        public static OrderDataStore CreateOrderDataStore()
        {
            return new OrderDataStore(OrderRepositoryFactory.GetInstance(), OrderItemRepositoryFactory.GetInstance());
        }

        #region factory setters
        //public static void SetItemRepositoryFactory(IRepositoryFactory<IItemRepository> factory) {
        //    ItemRepositoryFactory = factory;
        //}

        //public static void SetUserRepositoryFactory(IRepositoryFactory<IUserRepository> factory)
        //{
        //    UserRepositoryFactory = factory;
        //}
        //public static void SetCartRepositoryFactory(IRepositoryFactory<ICartRepository> factory)
        //{
        //    CartRepositoryFactory = factory;
        //}
        //public static void SetOrderRepositoryFactory(IRepositoryFactory<IOrderRepository> factory)
        //{
        //    ItemRepositoryFactory = factory;
        //}
        //public static void SetItemRepositoryFactory(IRepositoryFactory<IItemRepository> factory)
        //{
        //    ItemRepositoryFactory = factory;
        //}
        #endregion
    }
}
