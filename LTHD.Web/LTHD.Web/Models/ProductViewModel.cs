﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTHD.Web.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}