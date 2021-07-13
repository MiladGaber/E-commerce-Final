using Data_Access_Layer__DAL_;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.Repositories
{
    // created ...mark
    public class RoleRepository
    {
        AppRoleManager manager;
        public RoleRepository(DbContext db)
        {
            manager = new AppRoleManager(db);
        }

        public IdentityResult Create(string role)
        {
            return manager.CreateAsync(new IdentityRole(role)).Result;
        }
    }
}
