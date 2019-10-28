using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UICRM.Areas.CRMarea.Models
{
    public class CustomerPersonVM
    {
        public CustomerPersonVM()
        {
            Customers = new List<Customer>();
            CustomerPer = new CustomerPersonDTO();
        }

       
        public List<Customer> Customers { get; set; }
        public CustomerPersonDTO CustomerPer { get; set; }


    }
}