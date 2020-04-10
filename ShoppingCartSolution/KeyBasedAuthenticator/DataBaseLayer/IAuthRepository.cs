using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyBasedAuthenticator.Models;

namespace KeyBasedAuthenticator.DataBaseLayer
{
    public interface IAuthRepository
    {
        AppUser GetAppUser(Guid id);

        AppUser AddAppUser(AppUser user);

        AppUser RemoveAppUser(AppUser user);

        void RemoveAll();
    }
}
