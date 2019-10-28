using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entity
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TCNo { get; set; }
        public string UserName { get; set; }
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Min 6 and max 10 characters")]
        public string Password { get; set; }


    }
}
