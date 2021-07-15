using Business_Layer__BL_.AppServices;
using Business_Layer__BL_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        ProductAppService productAppService = new ProductAppService();

        //Alow For all
        #region Get All
        public ActionResult Index()
        {
            return View(productAppService.GetAllProduct());
        }
        #endregion

        //Allow for all
        #region Show Details
        public ActionResult Details(int id)
        {
            return View(productAppService.GetProduct(id));
        }
        #endregion //All

        //Allow for Admin
        #region Create New
       
        [Authorize(Roles = "Admin")]
        public ActionResult Create() => View();

        // POST: Product2/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(ProductViewModel product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                try
                {
                    productAppService.SaveNewOrder(product);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(product);
                }
            }

        }
        #endregion

        //Allow for Admin
        #region Update
        
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id)
        {
            return View();
        }

        // POST: Product2/Edit/5
        [HttpPost]
        public ActionResult Update(int id, ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    try
                    {
                        productAppService.UpdateOrder(product);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(product);
                    }
                }
            }
        }
        #endregion

        //Allow For Admin
        #region Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            productAppService.DeleteOrder(id);
            return RedirectToAction("Index");
        } 
        #endregion
    }
}