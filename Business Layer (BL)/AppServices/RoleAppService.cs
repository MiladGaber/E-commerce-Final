using Business_Layer__BL_.Bases;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.AppServices
{
    //Created...mark
    public class RoleAppService:AppServiceBase
    {
        public IdentityResult Create(string rolename)
        {
            return TheUnitOfWork.Role.Create(rolename);
        }
    }
}
