using Business_Layer__BL_.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    // [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        // GET: Role
        RoleAppService roleAppSevice = new RoleAppService();
        public ActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewRole(string RoleName)
        {
            if (RoleName != null)
            {
                roleAppSevice.Create(RoleName);
                ViewData["Status"] = "Add Succss";
                return View();
            }
            else
            {
                ViewData["Status"] = "Role Name Empty";
                return View();
            }


        }
    }
}