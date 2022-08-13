using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanGiay.Context;

namespace WebsiteBanGiay.Models
{
    public class CategoryModel
    {
        public List<SanPham> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }
    }
}