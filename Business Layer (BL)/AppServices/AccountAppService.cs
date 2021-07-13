using Business_Layer__BL_.Bases;
using Business_Layer__BL_.ViewModels;
using Data_Access_Layer__DAL_;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.AppServices
{
    class AccountAppService:AppServiceBase
    {
        //created ...mark
        //Login
        public AppIdentityUser Find(string name, string passworg)
        {
            return TheUnitOfWork.Account.Find(name, passworg);
        }
        public IdentityResult Register(RegisterViewModel user)
        {
            AppIdentityUser identityUser =
                Mapper.Map<RegisterViewModel, AppIdentityUser>(user);
            return TheUnitOfWork.Account.Register(identityUser);

        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);


        }

    }
}
