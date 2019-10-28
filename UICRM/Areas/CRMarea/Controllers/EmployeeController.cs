using DAL.ORM.Entity;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UICRM.Areas.CRMarea.Models;
using UICRM.Models;

namespace UICRM.Areas.CRMarea.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: CRMarea/Employee

        EmployeeService empService = new EmployeeService();

        public ActionResult List()
        {
            
            return View(empService.GetActive());


        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(Employee data)
        {
            
                if (empService.Any(x => x.UserName == data.UserName)) return Redirect("/CRMarea/Employee/List");
                //PassCrypto.base64Encode(data.Password);
                
                empService.Add(data);
                return Redirect("/CRMarea/Employee/List");
          

           

        }

        public ActionResult Edit( int? id)
        {
            int a = (int) TempData["idm"];
            Employee emp = empService.GetById(a);
            EmployeeDTO model = new EmployeeDTO();

            model.Id = emp.ID;
            model.Name = emp.Name;
            model.Surname = emp.Surname;
            model.TCNo = emp.TCNo;
            model.Email = emp.Email;
            model.Phone = emp.Phone;
            model.UserName = emp.UserName;
            model.Password = PassCrypto.base64Decode(emp.Password);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(EmployeeDTO data)
        {
            Employee emp = empService.GetById(data.Id);

            emp.Name = data.Name;
            emp.Surname = data.Surname;
            emp.TCNo = data.TCNo;
            emp.Email = data.Email;
            emp.Phone = data.Phone;
            emp.UserName = data.UserName;
            emp.Password = data.Password;

            empService.Update(emp);
            return Redirect("/CRMarea/Employee/List");

        }

    }
}