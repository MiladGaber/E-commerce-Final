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
        public class AdminController : Controller
        {

            AccountAppService accountAppService = new AccountAppService();

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