using Business_Layer__BL_.AppServices;
using Business_Layer__BL_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
   // [Authorize]
    public class CategoryController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();

        //Allow For All
        #region Get All
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(categoryAppService.GetAllCategory());
        }
        #endregion

        //Allow for All
        #region Show Details
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(categoryAppService.GetCategory(id));
        }
        #endregion

        //Allow For Admin
        #region Create New
      //  [Authorize(Roles = "Admin")]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(CategoryViewModel category)
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
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    return View(category);
                }
            }
        }
        #endregion

        //Allow For Admin
        #region Update
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id) => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id, CategoryViewModel category)
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
        #endregion

        //Allow For All
        #region Delete
        [Authorize]
        public ActionResult Delete(int id)
        {
            categoryAppService.DeleteCategory(id);
            return RedirectToAction("Index");
        } 
        #endregion
    }
}