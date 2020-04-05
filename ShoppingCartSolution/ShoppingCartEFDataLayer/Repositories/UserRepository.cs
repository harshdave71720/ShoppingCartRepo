using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartLibrary;
using ShoppingCartDataLayer.Repositories;
using ShoppingCartEFDataLayer.DbContexts;

namespace ShoppingCartEFDataLayer.Repositories
{
    public class UserRepository : EFRepositoryBase<User> , IUserRepository
    {
        
        public UserRepository(ShoppingDbContext context) : base(context){
            
        }

        public User Add(User obj)
        {
            var user = Context.Users.Add(obj);
            Context.SaveChanges();
            return user;
        }

        public User Find(User Obj)
        {
            return Context.Users.Find(Obj.Id);
        }

        public IEnumerable<User> GetAll()
        {
            return Context.Users;
        }

        public User Remove(User obj)
        {
            var user = Context.Users.Find(obj.Id);
            if (user == null) {
                return null;
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return user;
        }

        public User Update(User obj)
        {
            throw new NotImplementedException();
        }

        //public int SaveChanges() {
        //    return Db.SaveChanges();
        //}

        public void Dispose() {
            Context.Dispose();
        }
    }
}