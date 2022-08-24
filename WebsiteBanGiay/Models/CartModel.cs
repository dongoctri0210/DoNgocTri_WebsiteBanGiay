
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanGiay.Context;

namespace WebsiteBanGiay.Models
{
    public class CartModel
    {
        public SanPham Product { get; set; }
        public int Quantity {get;set;}
    }
}