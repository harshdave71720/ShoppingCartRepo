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
    public class UserManager
    {
        private UserDataStore UserStore;

        public UserManager(UserDataStore dataStore) {
            this.UserStore = dataStore;
        }

        public User AddUser(User user)
        {
            return UserStore.Add(user);
        }

        public User GetUser(Guid id)
        {
            return UserStore.Find(new User { Id = id });
        }

        public User UpdateUser(User user)
        {
            return UserStore.Update(user);
        }

        //public User RemoveUser(Guid id)
        //{
        //    return UserStore.Remove(new User { Id = id });
        //}
    }
}
