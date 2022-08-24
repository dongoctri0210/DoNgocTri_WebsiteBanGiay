using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGiay.Context;

namespace WebsiteBanGiay.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanGiayEntities ojbWebsiteBanGiayEntities = new WebsiteBanGiayEntities();
        // GET: Product
        public ActionResult Detail( int ID)
        {
            var objProduct = ojbWebsiteBanGiayEntities.SanPhams.Where(n => n.ID==ID).FirstOrDefault();
            return View(objProduct);
        }
    }
}