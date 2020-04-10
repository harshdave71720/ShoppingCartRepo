using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyBasedAuthenticator.DataBaseLayer;
using KeyBasedAuthenticator.Models;
using ShoppingSystemWebAPI.Authentication;

namespace ShoppingSystemWebAPI.Authentication
{
    public class AuthRepository : IAuthRepository
    {
        private AuthDbContext Db;
        public AuthRepository(){
            Db = new AuthDbContext("ShoppingCartDatabase");
        }

        public AppUser AddAppUser(AppUser user)
        {
            var result = Db.AppUsers.Add(user);
            Db.SaveChanges();
            return result;
        }

        public AppUser GetAppUser(Guid id)
        {
            return Db.AppUsers.Find(id);
        }

        public void RemoveAll()
        {
            Db.AppUsers.RemoveRange(Db.AppUsers);
            Db.SaveChanges();
        }

        public AppUser RemoveAppUser(AppUser user)
        {
            AppUser result = null;
            try {
                result = Db.AppUsers.Remove(user);
            }
            catch (Exception ex) {
                return null;
            }
            Db.SaveChanges();
            return result;
        }
    }
}