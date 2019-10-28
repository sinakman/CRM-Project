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
    public class ProductController : Controller
    {
        // GET: CRMarea/Product
        ProductService _productSrv = new ProductService();

        public ActionResult List()
        {
            return View(_productSrv.GetActive());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productSrv.GetById((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product data)
        {
            _productSrv.Add(data);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("List");
            Product product = _productSrv.GetById((int)id);
            ProductDTO model = new ProductDTO();

            model.Id = product.ID;
            model.Name = product.Name;
            model.ProductNumber = product.ProductNumber;
            model.Description = product.Description;
            model.ReleaseDate = product.ReleaseDate;

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(ProductDTO data)
        {
            Product product = _productSrv.GetById(data.Id);

            product.Name = data.Name;
            product.ProductNumber = data.ProductNumber;
            product.ReleaseDate = data.ReleaseDate;
            product.Description = data.Description;

            _productSrv.Update(product);
            return Redirect("/CRMarea/Product/List");

        }

        public RedirectResult Del(int id)
        {
            _productSrv.Remove(id);
            return Redirect("/CRMarea/Product/List");
        }

        public ActionResult ExportToExcel()
        {
            var product = this._productSrv.GetActive();

            var grid = new GridView();
            grid.DataSource = from c in product
                              select new
                              {
                                  No=c.ProductNumber,
                                  Adi = c.Name,
                                  Yayin_Taihi=c.ReleaseDate,
                                  Aciklama=c.Description

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

        public ActionResult ExPdf()
        {
            List<Product> model = _productSrv.GetActive();
            ViewAsPdf pdf = new ViewAsPdf("List", model);
            return pdf;
        }

        public ActionResult ExPdfDetail()
        {
            List<Product> model = _productSrv.GetActive();
            ViewAsPdf pdf = new ViewAsPdf("Details", model);
            return pdf;
        }

    }
}