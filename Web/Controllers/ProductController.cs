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

        // GET: Product
        public ActionResult Index()
        {
            return View(productAppService.GetAllProduct());
        }



        public ActionResult Details(int id)
        {
            return View(productAppService.GetProduct(id));
        }


        [Authorize]
        public ActionResult Create() => View();

        // POST: Product2/Create
        [HttpPost]
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


        [Authorize]
        public ActionResult Update(int id)
        {
            return View();
        }

        // POST: Product2/Edit/5
        [HttpPost]
        public ActionResult Update(int id, ProductViewModel product)
        {
            try
            {
                productAppService.UpdateOrder(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            productAppService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}