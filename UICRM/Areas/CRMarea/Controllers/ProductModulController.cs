using DAL.ORM.Context;
using DAL.ORM.Entity;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UICRM.Areas.CRMarea.Controllers
{
    public class ProductModulController : Controller
    {
        // GET: CRMarea/ProductModul
        ProductModuleService _pmServ = new ProductModuleService();
        ProductService _productServ = new ProductService();

        public ActionResult AllList()
        {
            return View(_pmServ.GetActive());
        }

        public ActionResult List(int? id)
        {

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //ProductModule module = new ProductModule();

            //var prM = db.ProductModules.SelectMany(x => x.Product.ProductModules.Select(p => p.ProductID == id));

            ////var prodModule = _pmServ.GetByDefault(p => p.ProductID == id);
            //if (prM == null)
            //{
            //    return HttpNotFound();
            //}
            List<ProductModule> data = _pmServ.GetDefault(x => x.ProductID == id && x.Status == DAL.ORM.Entity.Enum.Status.Active).ToList();
            
            return View(data);
        }

        public ActionResult Add(int? id)
        {

            //List<Product> data = _productServ.GetDefault(x => x.ID == id).ToList();

            Product data = _productServ.GetById((int)id);
            return View(data);
        }

        [HttpPost]
        public RedirectResult Add(ProductModule data)
        {
            _pmServ.Add(data);
            return Redirect("/CRMarea/Product/List");
        }

        public RedirectResult Del(int id)
        {
            _pmServ.Remove(id);
            return Redirect("/CRMarea/ProductModul/AllList");
        }

    }
}