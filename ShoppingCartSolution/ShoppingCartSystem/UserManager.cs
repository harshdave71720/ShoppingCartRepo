using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartSystem
{
    public class UserManager : ShoppingSystemManager
    {
        public UserManager(IDataSource dataSource) : base(dataSource) { }

        public User AddUser(User user)
        {
            return DataSource.Users.Add(user);
        }

        public User GetUser(Guid id)
        {
            return DataSource.Users.Find(new User { Id = id });
        }

        public User UpdateUser(User user)
        {
            return DataSource.Users.Update(user);
        }

        public User RemoveUser(Guid id)
        {
            return DataSource.Users.Remove(new User { Id = id });
        }
    }
}
