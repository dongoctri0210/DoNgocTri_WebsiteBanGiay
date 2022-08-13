using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGiay.Context;
using WebsiteBanGiay.Models;

namespace WebsiteBanGiay.Controllers
{
    public class HomeController : Controller
    {
        
        WebsiteBanGiayEntities3 ojbWebsiteBanGiayEntities = new WebsiteBanGiayEntities3();
        public ActionResult Index()
        {
            HomeModel ojbHomeModel = new HomeModel();
            ojbHomeModel .ListProduct = ojbWebsiteBanGiayEntities.SanPhams.ToList();
            ojbHomeModel.ListCategory = ojbWebsiteBanGiayEntities.Categories.ToList();
            return View(ojbHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}