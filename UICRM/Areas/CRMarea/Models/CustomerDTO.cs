using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UICRM.Areas.CRMarea.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DBtype { get; set; }
        public string AppServer { get; set; }

    }
}