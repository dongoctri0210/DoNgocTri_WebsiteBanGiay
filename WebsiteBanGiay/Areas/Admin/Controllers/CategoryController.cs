using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGiay.Context;

namespace WebsiteBanGiay.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanGiayEntities ojbWebsiteBanGiayEntities = new WebsiteBanGiayEntities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var ListCategory = ojbWebsiteBanGiayEntities.Categories.ToList();
            return View(ListCategory);
        }
        public ActionResult Details(int ID)
        {
            var objCategory = ojbWebsiteBanGiayEntities.Categories.Where(n => n.Id == ID).FirstOrDefault();
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category objCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objCategory.CreatedOnUtc = DateTime.Now;
                    ojbWebsiteBanGiayEntities.Categories.Add(objCategory);
                    ojbWebsiteBanGiayEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objCategory);
        }
        public ActionResult Delete(int ID)
        {
            var objCategory = ojbWebsiteBanGiayEntities.Categories.Where(n => n.Id == ID).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Delete(Category objLSP)
        {
            var objCategory = ojbWebsiteBanGiayEntities.Categories.Where(n => n.Id == objLSP.Id).FirstOrDefault();
            ojbWebsiteBanGiayEntities.Categories.Remove(objCategory);
            ojbWebsiteBanGiayEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var objCategory = ojbWebsiteBanGiayEntities.Categories.Where(n => n.Id == ID).FirstOrDefault();
            return View(objCategory);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, Category objCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objCategory.CreatedOnUtc = DateTime.Now;
                    ojbWebsiteBanGiayEntities.Categories.Add(objCategory);
                    ojbWebsiteBanGiayEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objCategory);
        }
    }
}