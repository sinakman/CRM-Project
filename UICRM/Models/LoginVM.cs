using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UICRM.Models
{
    public class LoginVM
    {
        

        [Required(ErrorMessage = "Kullanıcı adını boş geçemezsiniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifreyi boş geçemezsiniz!")]
        public string PasSword { get; set; }


        
    }
}