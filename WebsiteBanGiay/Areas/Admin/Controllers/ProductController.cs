using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGiay.Context;
using WebsiteBanGiay.Models;
using static WebsiteBanGiay.Common;

namespace WebsiteBanGiay.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanGiayEntities ojbWebsiteBanGiayEntities = new WebsiteBanGiayEntities();
        // GET: Admin/Product
        public ActionResult Index(string currentFilter,string SearchString,int? page)
        {
            var ListProduct = new List<SanPham>();
            if(SearchString !=null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if(!string.IsNullOrEmpty(SearchString))
            {
                //Tìm kiếm danh sách sản phẩm theo tên
                ListProduct = ojbWebsiteBanGiayEntities.SanPhams.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                // Lấy ra tất cả sản phẩm
                ListProduct = ojbWebsiteBanGiayEntities.SanPhams.ToList();
            }
            ViewBag.CurrentFiler = SearchString;
            int pageSize = 3; //Số sản phẩm mỗi trang là 2
            int pageNumber = (page ?? 1);
            //Sắp xếp theo id sản phẩm,mới đưa lên đầu
            ListProduct = ListProduct.OrderByDescending(n => n.ID).ToList();
            return View(ListProduct.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Details(int ID)
        {
            var objProduct = ojbWebsiteBanGiayEntities.SanPhams.Where(n => n.ID == ID).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(SanPham objproduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objproduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objproduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objproduct.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objproduct.Avatar = fileName;
                        objproduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objproduct.CreatedDate = DateTime.Now;
                    ojbWebsiteBanGiayEntities.SanPhams.Add(objproduct);
                    ojbWebsiteBanGiayEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objproduct);
        }
       void LoadData()
        {
            Common objcommon = new Common();
            //Lấy dữ liệu danh mục từ DB
            var lstCat = ojbWebsiteBanGiayEntities.Categories.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objcommon.ToSelectList(dtCategory, "Id", "Name");

            //Lấy dữ liệu thương hiệu từ DB
            var lstBrand = ojbWebsiteBanGiayEntities.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = objcommon.ToSelectList(dtBrand, "Id", "Name");

            //Loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.ID = 1;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.ID = 2;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.ProductType = objcommon.ToSelectList(dtProductType, "Id", "Name");

        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var objProduct = ojbWebsiteBanGiayEntities.SanPhams.Where(n => n.ID == ID).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(SanPham objSP)
        {
            var objProduct = ojbWebsiteBanGiayEntities.SanPhams.Where(n => n.ID == objSP.ID).FirstOrDefault();
            ojbWebsiteBanGiayEntities.SanPhams.Remove(objProduct);
            ojbWebsiteBanGiayEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            this.LoadData();
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id,SanPham objProduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objProduct.CreatedDate = DateTime.Now;
                    ojbWebsiteBanGiayEntities.SanPhams.Add(objProduct);
                    ojbWebsiteBanGiayEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objProduct);
        }
    }
}