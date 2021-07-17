using Business_Layer__BL_.AppServices;
using Business_Layer__BL_.ViewModels;
using Data_Access_Layer__DAL_;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    //  [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {


        AccountAppService accountAppService = new AccountAppService();
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();
        OrderAppSevice orderAppSevice = new OrderAppSevice();



        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }
        //Allow Dashboard For All
        [AllowAnonymous]
        public ActionResult Dashboard()
        {
            ViewBag.TotalCategories = categoryAppService.GetAllCategory().Count;
            ViewBag.TotalProducts = productAppService.GetAllProduct().Count;
            ViewBag.TotalOrders = orderAppSevice.GetAllOrder().Count;
            return View();
        }

        //******************************* Start Categories Actions ******************************//

        // Show All Categories in table
        public ActionResult Categories()
        {
            return View(categoryAppService.GetAllCategory());
        }

        public ActionResult CategoryDetails(int id)
        {
            return View(categoryAppService.GetCategory(id));
        }

        [AllowAnonymous]
        //  [Authorize(Roles = "Admin")]
        public ActionResult CreateCategory() => View();

        [HttpPost]
        public ActionResult CreateCategory(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                try
                {
                    categoryAppService.SaveNewCategory(category);
                    return RedirectToAction("Categories");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    return View(category);
                }
            }
        }
        //Allow For Admin
        //[Authorize(Roles = "Admin")]
        public ActionResult UpdateCategory(int id) => View();

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult UpdateCategory(int id, CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                try
                {
                    categoryAppService.UpdateCategory(category);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    return View(category);
                }
            }
        }

        //Allow For All
        //[Authorize]
        public ActionResult DeleteCategory(int id)
        {
            categoryAppService.DeleteCategory(id);
            return RedirectToAction("Index");
        }


        //**************************** End Categories Actions ******************************//


        public ActionResult Products()
        {
            return View(productAppService.GetAllProduct());
        }

        public ActionResult Orders()
        {
            return View(orderAppSevice.GetAllOrder());
        }

        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                IdentityResult result = accountAppService.Register(user);
                if (result.Succeeded)
                {
                    accountAppService.AssignToRole(user.UserName, "Admin");
                    IAuthenticationManager owinManger = HttpContext.GetOwinContext().Authentication;

                    SignInManager<AppIdentityUser, string> sign = new SignInManager<AppIdentityUser, string>(
                        new AppUserManager(), owinManger
                        );

                    AppIdentityUser identityUser = accountAppService.Find(user.UserName, user.PasswordHash);

                    sign.SignIn(identityUser, true, true);
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    foreach (var errors in result.Errors)
                    {
                        ModelState.AddModelError("", errors);
                    }
                    return View(user);
                }
            }
        }


        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                AppIdentityUser identityUser = accountAppService.Find(user.UserName, user.PasswordHash);
                if (identityUser != null)
                {

                    IAuthenticationManager owinManger = HttpContext.GetOwinContext().Authentication;

                    SignInManager<AppIdentityUser, string> sign = new SignInManager<AppIdentityUser, string>(
                        new AppUserManager(), owinManger
                        );

                    sign.SignIn(identityUser, true, true);
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Username & Password Not Valid");
                    return View(user);
                }
            }
        }


        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager owinManger = HttpContext.GetOwinContext().Authentication;
            owinManger.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}