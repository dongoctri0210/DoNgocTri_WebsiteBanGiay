using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGiay.Context;
using WebsiteBanGiay.Models;

namespace WebsiteBanGiay.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBanGiayEntities ojbWebsiteBanGiayEntities = new WebsiteBanGiayEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //Lấy thông tin từ giỏ hàng từ biến session
                var ListCart = (List<CartModel>)Session["Cart"];
                //Gán dữ liệu cho Order
                Order objOrder = new Order();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserID = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                ojbWebsiteBanGiayEntities.Orders.Add(objOrder);
                //Lưu thông tin dữ liệu vào bảng order
                ojbWebsiteBanGiayEntities.SaveChanges();
                //Lấy OrderID vừa mới tạo để thêm vào bảng OrderDetail
                int intOrderID = objOrder.ID;
                List<OrderDetail> listOrderDetail = new List<OrderDetail>();
                foreach(var item in ListCart)
                {
                    OrderDetail objOrderDetail = new OrderDetail();
                    objOrderDetail.Quantity = item.Quantity;
                    objOrderDetail.OrderID = intOrderID;
                    objOrderDetail.ProductID = item.Product.ID;
                    listOrderDetail.Add(objOrderDetail);
                }
                ojbWebsiteBanGiayEntities.OrderDetails.AddRange(listOrderDetail);
                ojbWebsiteBanGiayEntities.SaveChanges();
            }
            return View();
        }
    }
}