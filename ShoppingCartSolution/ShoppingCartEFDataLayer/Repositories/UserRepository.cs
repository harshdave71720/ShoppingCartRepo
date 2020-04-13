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

        public UserRepository() : this(ShoppingDbContextFactory.GetInstance()) { 
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
            var user = Context.Users.Find(obj.Id);
            if (user == null)
            {
                return user;
            }
            if (obj.Name != null)
                user.Name = obj.Name;
            if (obj.Email != null)
                user.Email = obj.Email;
            if (obj.Address != null)
                user.Address = obj.Address;

            //Context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return Context.Users.Find(obj.Id);
        }

        //public int SaveChanges() {
        //    return Db.SaveChanges();
        //}

        public void Dispose() {
            Context.Dispose();
        }
    }
}