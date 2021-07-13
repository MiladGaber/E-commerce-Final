using Data_Access_Layer__DAL_;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.Repositories
{
    //created by ...mark
    public class AccountRepository
    {
        AppUserManager manager;

        public AccountRepository(DbContext db)
        {
            manager = new AppUserManager(db);
        }
        public AppIdentityUser Find(string username, string password)
        {
            AppIdentityUser result = manager.Find(username, password);
            return result;

        }
        public IdentityResult Register(AppIdentityUser user)
        {
            IdentityResult result = manager.Create(user, user.PasswordHash);
            return result;
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;
        }
    }
}
