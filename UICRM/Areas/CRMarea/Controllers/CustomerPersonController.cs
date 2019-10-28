using DAL.ORM.Entity;
using Service.Option;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using UICRM.Areas.CRMarea.Models;

namespace UICRM.Areas.CRMarea.Controllers
{
    public class CustomerPersonController : Controller
    {
        // GET: CRMarea/CustomerPerson
        CustomerPersonService _customerPerson = new CustomerPersonService();
        CustomerService _custService = new CustomerService();
        public ActionResult List(int? id)
        {

            List<CustomerPerson> data = _customerPerson.GetDefault(x => x.CustomerID == id).ToList();
           
            return View(data);
        }

        public ActionResult Add(int? id)
        {
            Customer customer = _custService.GetById((int)id);
            return View(customer);
        }

        [HttpPost]
        public RedirectResult Add(CustomerPerson data)
        {
            _customerPerson.Add(data);
            return Redirect("/CRMarea/Customer/List");
        }

        public ActionResult Edit(int? id)
        {
            CustomerPersonVM model = new CustomerPersonVM();
            CustomerPerson custo = _customerPerson.GetById((int)id);
            model.CustomerPer.Id = custo.ID;
            model.CustomerPer.Name = custo.Name;
            model.CustomerPer.Surname = custo.SurName;
            model.CustomerPer.Phone = custo.Phone;
            model.CustomerPer.Mphone = custo.MobilePhone;
            model.CustomerPer.Email = custo.Email;
            model.CustomerPer.Title = custo.Title;
            model.Customers = _custService.GetActive();

            return View(model);
        }

        [HttpPost]
        public RedirectResult Edit(CustomerPersonDTO data)
        {
            CustomerPerson cp = _customerPerson.GetById(data.Id);
            cp.Name = data.Name;
            cp.SurName = data.Surname;
            cp.Phone = data.Phone;
            cp.MobilePhone = data.Mphone;
            cp.Email = data.Email;
            cp.Title = data.Title;
            cp.CustomerID = data.CustomerID;
            _customerPerson.Update(cp);
            return Redirect("/CRMarea/Customer/List");
        }

        public RedirectResult Del(int id)
        {
            _customerPerson.Remove(id);
            return Redirect("/CRMarea/Customer/List");

        }

        public ActionResult ExportToExcel()
        {
            var customerP = this._customerPerson.GetActive();

            var grid = new GridView();
            grid.DataSource = from c in customerP
                              select new
                              {
                                  Musteri = c.Customer.Name,
                                  Adi = c.Name,
                                  Soyadi=c.SurName,
                                  Eposta=c.Email,
                                  Cep=c.MobilePhone,
                                  Tel = c.Phone,
                                  Pozisyon=c.Title
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

    }
}