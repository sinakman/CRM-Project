using DAL.ORM.Entity;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UICRM.Areas.CRMarea.Controllers
{
    public class TroubleShootController : Controller
    {
        // GET: CRMarea/TroubleShoot
        TroubleShootService _tsServ = new TroubleShootService();
        CustomerService _custServ = new CustomerService();
        ProductService _proServ = new ProductService();

        public ActionResult List()
        {
            
            return View(_tsServ.GetActive());
        }
        public ActionResult ListByCustomer(int? id)
        {
           
            List<TroubleShoot> tS = _tsServ.GetDefault(x => x.CustomerID == id).ToList();

            return View(tS);
        }

        public ActionResult Add()
        {
            return View(Tuple.Create<List<Customer>, List<Product>, TroubleShoot>(_custServ.GetActive(), _proServ.GetActive(), new TroubleShoot()));
        }

        [HttpPost]
        public ActionResult Add([Bind(Prefix = "Item3")]TroubleShoot item)
        {
            _tsServ.Add(item);
            return RedirectToAction("List");
        }

        public ActionResult Edit()
        {
            return View();
        }
        public RedirectResult Del(int id)
        {
            _tsServ.Remove(id);
            return Redirect("/CRMarea/TroubleShoot/List");
        }

        public ActionResult Added()
        {
            return View(Tuple.Create<List<Customer>, List<Product>, TroubleShoot>(_custServ.GetActive(), _proServ.GetActive(), new TroubleShoot()));
        }

        [HttpPost]
        public ActionResult Added([Bind(Prefix = "Item3")]TroubleShoot item)
        {
            _tsServ.Add(item);
            return RedirectToAction("List");
        }


    }
}