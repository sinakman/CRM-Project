﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UICRM.Areas.CRMarea.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string ProductNumber { get; set; }
    }
}