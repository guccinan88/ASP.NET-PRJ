using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOM.Models
{
    public class ViewModel
    {
        public List<Product> Products { get; set; }
        public List<Material> Materials { get; set; }
    }
}