using Business_Layer__BL_.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        OrderAppSevice orderAppSevice = new OrderAppSevice();


        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        
        public ActionResult Caregories()
        {
            return View(categoryAppService.GetAllCategory());
        }
  
        public ActionResult Orders()
        {
            return View(orderAppSevice.GetAllOrder());
        }
    }
}