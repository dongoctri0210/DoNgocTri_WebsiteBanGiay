using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGiay.Context;
using WebsiteBanGiay.Models;

namespace WebsiteBanGiay.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanGiayEntities3 ojbWebsiteBanGiayEntities = new WebsiteBanGiayEntities3();
        // GET: Category
        public ActionResult Index()
        {
            var ListCategory = ojbWebsiteBanGiayEntities.Categories.ToList();
            return View(ListCategory);
        }
        public ActionResult ProductCategory(int ID)
        {
            CategoryModel ojbCategoryModel = new CategoryModel();
            ojbCategoryModel.ListProduct = ojbWebsiteBanGiayEntities.SanPhams.Where(n=>n.CategoryID == ID).ToList();
            ojbCategoryModel.ListCategory = ojbWebsiteBanGiayEntities.Categories.ToList();
            return View(ojbCategoryModel);
        }
    }
}