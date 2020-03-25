using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;

namespace ShoppingCartWebAPI.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ShoppingDbContext Db;
        public UserRepository(ShoppingDbContext context) {
            Db = context;
        }

        public User Add(User obj)
        {
            var user = Db.Users.Add(obj);
            Db.SaveChanges();
            return user;
        }

        public User Find(User Obj)
        {
            return Db.Users.Find(Obj.Id);
        }

        public IEnumerable<User> GetAll()
        {
            return Db.Users;
        }

        public User Remove(User obj)
        {
            var user = Db.Users.Find(obj.Id);
            Db.Users.Remove(user);
            Db.SaveChanges();
            return user;
        }

        public User Update(User obj)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges() {
            return Db.SaveChanges();
        }

        public void Dispose() {
            Db.Dispose();
        }
    }
}