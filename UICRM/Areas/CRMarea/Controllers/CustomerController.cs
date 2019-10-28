using DAL.ORM.Entity;
using Rotativa;
using Service.Option;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using UICRM.Areas.CRMarea.Models;
using UICRM.AuthFilter;

namespace UICRM.Areas.CRMarea.Controllers
{
    [EmployeeAuthentication]

    public class CustomerController : Controller
    {
        // GET: CRMarea/Customer

        CustomerService _CustService = new CustomerService();
        public ActionResult List()
        {
            return View(_CustService.GetActive());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _CustService.GetById((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer data)
        {
            _CustService.Add(data);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            
            if (id==null) return RedirectToAction("List");

            Customer customer = _CustService.GetById((int)id);
            CustomerDTO model = new CustomerDTO();

            model.Id = customer.ID;
            model.Name = customer.Name;
            model.Phone = customer.Phone;
            model.Address = customer.Address;
            model.AppServer = customer.AppServer;
            model.DBtype = customer.DBType;

            return View(model);
        }

        [HttpPost]
        public RedirectResult Edit(CustomerDTO data)
        {
            Customer cust = _CustService.GetById(data.Id);
            //if (_CustService.Any(x => x.Name == data.Name)) return Redirect("/CRMarea/Customer/List");

            cust.Name = data.Name;
            cust.Phone = data.Phone;
            cust.Address = data.Address;
            cust.DBType = data.DBtype;
            cust.AppServer = data.AppServer;

            _CustService.Update(cust);
            return Redirect("/CRMarea/Customer/List");

        }

        public RedirectResult Del(int id)
        {
            _CustService.Remove(id);
            return Redirect("/CRMarea/Customer/List");
        }

        public ActionResult ExportToExcel()
        {
            var customers = this._CustService.GetActive();

            var grid = new GridView();
            grid.DataSource = from c in customers
                              select new
                              {
                                  Id = c.ID,
                                  Adı = c.Name,
                                  Tel=c.Phone,
                                  Adres=c.Address
                              };
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return View();
        }

        

        public ActionResult ExpPDF()
        {
            List<Customer> model = _CustService.GetActive();
            ViewAsPdf pdf = new ViewAsPdf("List", model);
            return pdf;

            //return new ActionAsPdf("List")
            //{
            //    FileName = Server.MapPath("~/Content/ListCustomer/")
            //};
            
        }
    }
}

        


        


