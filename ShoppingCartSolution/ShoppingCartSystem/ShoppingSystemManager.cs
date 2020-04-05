using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartLibrary;
using ShoppingCartDataLayer.Repositories;

namespace ShoppingCartSystem
{
    public class ShoppingSystemManager
    {
        private IDataSource DataSource;

        public ShoppingSystemManager(IDataSource dataSource) {
            DataSource = dataSource;
        }

        public User AddUser(User user) {
            return DataSource.Users.Add(user);
        }

        public User GetUser(Guid id) {
            return DataSource.Users.Find(new User { Id = id});
        }

        public User UpdateUser(User user) {
            return DataSource.Users.Update(user);
        }

        public User RemoveUser(Guid id) {
            return DataSource.Users.Remove(new User { Id = id});
        }
    }
}
