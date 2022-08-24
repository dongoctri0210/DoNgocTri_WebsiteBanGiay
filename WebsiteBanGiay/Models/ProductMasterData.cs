using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanGiay.Models
{
    public partial class ProductMasterData
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm")]
        [Display(Name="Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Giá gốc")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShortDescription { get; set; }
        [Display(Name = "Mô tả đầy đủ")]
        public string FullDescription { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedUser { get; set; }
        public Nullable<int> UpdatedUser { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> TypeID { get; set; }
        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryID { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandID { get; set; }
    }
}