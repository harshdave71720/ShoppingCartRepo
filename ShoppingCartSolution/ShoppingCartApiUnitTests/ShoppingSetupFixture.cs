//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using Moq;
//using ShoppingCartLibrary;
//using ShoppingCartWebAPI;
//using ShoppingCartWebAPI.Repositories;

//namespace ShoppingCartApiUnitTests
//{
//    [SetUpFixture]
//    public class ShoppingSetupFixture
//    {

//        public static Mock<IDataSource> DataSource;
//        public static Mock<IRepository<Item>> ItemRepo;
//        public static Mock<IRepository<Cart>> CartRepo;
//        public static Mock<IRepository<Order>> OrderRepo;
//        public static Mock<IRepository<User>> UserRepo;

//        public static List<User> Users = new List<User>();
//        public static List<Order> Orders = new List<Order>();
//        public static List<Cart> Carts = new List<Cart>();
//        public static List<Item> Items = new List<Item>();

//        [OneTimeSetUp]
//        public void Initialize() {
//            DataSource = new Mock<IDataSource>();
//            ItemRepo = new Mock<IRepository<Item>>();
//            CartRepo = new Mock<IRepository<Cart>>();
//            OrderRepo = new Mock<IRepository<Order>>();
//            UserRepo = new Mock<IRepository<User>>();

//            ItemRepo.Setup(ir => ir.Add(It.IsAny<Item>())).Returns(new Item { Id = Guid.NewGuid() });
//            UserRepo.Setup(ir => ir.Add(It.IsAny<User>())).Returns(new User { Id = Guid.NewGuid() });
//            OrderRepo.Setup(ir => ir.Add(It.IsAny<Order>())).Returns(new Order { Id = Guid.NewGuid() });
//            CartRepo.Setup(ir => ir.Add(It.IsAny<Cart>())).Returns(new Cart { Id = Guid.NewGuid() });


//            ItemRepo.Setup(ir => ir.Find(It.Is<Item>(item => !Items.Any(i => i.Id.Equals(item.Id)))))
//                .Returns<Item>(null);

//            //ItemRepo.Setup(ir => Get(ir.Find(It.Is<Item>(item => Items.Any(i => i.Id.Equals(item.Id)))))).Returns(item);
            
//            ItemRepo.Setup(ir => ir.Find(It.Is<Item>(item => Items.Any(i => i.Id.Equals(item.Id)))))
//                .Returns(new Item { Id = Guid.NewGuid() });

//            ItemRepo.Setup(ir => ir.Remove(It.Is<Item>(item => !Items.Any(i => i.Id.Equals(item.Id)))))
//                .Returns<Item>(null);
//            ItemRepo.Setup(ir => ir.Remove(It.Is<Item>(item => Items.Any(i => i.Id.Equals(item.Id)))))
//                .Returns(new Item { Id = Guid.NewGuid() });

//            ItemRepo.Setup(ir => ir.Update(It.Is<Item>(item => !Items.Any(i => i.Id.Equals(item.Id)))))
//                .Returns<Item>(null);
//            ItemRepo.Setup(ir => ir.Update(It.Is<Item>(item => Items.Any(i => i.Id.Equals(item.Id)))))
//                .Returns(new Item { Id = Guid.NewGuid() });




//            UserRepo.Setup(ur => ur.Find(It.Is<User>(user => !Users.Any(i => i.Id.Equals(user.Id)))))
//                .Returns<User>(null);
//            UserRepo.Setup(ur => ur.Find(It.Is<User>(user => Users.Any(i => i.Id.Equals(user.Id)))))
//                .Returns(new User { Id = Guid.NewGuid() });

//            UserRepo.Setup(ur => ur.Update(It.Is<User>(user => !Users.Any(i => i.Id.Equals(user.Id)))))
//                .Returns<User>(null);
//            UserRepo.Setup(ur => ur.Update(It.Is<User>(user => Users.Any(i => i.Id.Equals(user.Id)))))
//                .Returns(new User { Id = Guid.NewGuid() });

//            UserRepo.Setup(ir => ir.Remove(It.Is<User>(user => !Users.Any(i => i.Id.Equals(user.Id)))))
//                .Returns<User>(null);
//            UserRepo.Setup(ir => ir.Remove(It.Is<User>(user => Users.Any(i => i.Id.Equals(user.Id)))))
//                .Returns(new User { Id = Guid.NewGuid() });



//            OrderRepo.Setup(or => or.Find(It.Is<Order>(order => !Orders.Any(i => i.Id.Equals(order.Id)))))
//                .Returns<Order>(null);
//            OrderRepo.Setup(or => or.Find(It.Is<Order>(order => Orders.Any(i => i.Id.Equals(order.Id)))))
//                .Returns(new Order { Id = Guid.NewGuid()});
//            OrderRepo.Setup(or => or.Remove(It.Is<Order>(order => !Orders.Any(i => i.Id.Equals(order.Id)))))
//                .Returns<Order>(null);
//            OrderRepo.Setup(or => or.Remove(It.Is<Order>(order => Orders.Any(i => i.Id.Equals(order.Id)))))
//                .Returns(new Order { Id = Guid.NewGuid() });
//            OrderRepo.Setup(or => or.Update(It.Is<Order>(order => !Orders.Any(i => i.Id.Equals(order.Id)))))
//                .Returns<Order>(null);
//            OrderRepo.Setup(or => or.Update(It.Is<Order>(order => Orders.Any(i => i.Id.Equals(order.Id)))))
//                .Returns(new Order { Id = Guid.NewGuid() });




//            CartRepo.Setup(cr => cr.Find(It.Is<Cart>(cart => !Carts.Any(i => i.Id.Equals(cart.Id)))))
//                .Returns<Cart>(null);
//            CartRepo.Setup(cr => cr.Find(It.Is<Cart>(cart => Carts.Any(i => i.Id.Equals(cart.Id)))))
//                .Returns(new Cart { Id = Guid.NewGuid()});
//            CartRepo.Setup(cr => cr.Remove(It.Is<Cart>(cart => !Carts.Any(i => i.Id.Equals(cart.Id)))))
//                .Returns<Cart>(null);
//            CartRepo.Setup(cr => cr.Remove(It.Is<Cart>(cart => Carts.Any(i => i.Id.Equals(cart.Id)))))
//                .Returns(new Cart { Id = Guid.NewGuid() });
//            CartRepo.Setup(cr => cr.Update(It.Is<Cart>(cart => !Carts.Any(i => i.Id.Equals(cart.Id)))))
//                .Returns<Cart>(null);
//            CartRepo.Setup(cr => cr.Update(It.Is<Cart>(cart => Carts.Any(i => i.Id.Equals(cart.Id)))))
//                .Returns(new Cart { Id = Guid.NewGuid() });


//            DataSource.Setup(d => d.Items).Returns(ItemRepo.Object);
//            DataSource.Setup(d => d.Orders).Returns(OrderRepo.Object);
//            DataSource.Setup(d => d.Users).Returns(UserRepo.Object);
//            DataSource.Setup(d => d.Carts).Returns(CartRepo.Object);

//        }

//        private object Get(object obj) {
//            return obj;
//        }
//    }
//}
