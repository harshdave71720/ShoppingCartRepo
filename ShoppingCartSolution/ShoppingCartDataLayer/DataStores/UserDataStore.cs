using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartLibrary;

namespace ShoppingCartDataLayer.DataStores
{
    public class UserDataStore
    {
        private IUserRepository UserRepository;
        public UserDataStore(IUserRepository repository) {
            UserRepository = repository;
        }
        
        public User Add(User user)
        {
            return UserRepository.Add(user);
        }

        public User Find(User user)
        {
            return UserRepository.Find(user);
        }

        //public User Remove(User user)
        //{
        //    return Users.Remove();
        //}

        public User Update(User user)
        {
            return UserRepository.Update(user);
        }
    }
}
