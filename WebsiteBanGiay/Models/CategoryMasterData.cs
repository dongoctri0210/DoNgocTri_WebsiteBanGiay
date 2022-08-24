using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanGiay.Models
{
    public partial class CategoryMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên loại sản phẩm")]
        [Display(Name = "Tên loại sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }
        [Display(Name = "Hiển thị")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        [Display(Name = "Ngừng bán")]
        public Nullable<bool> DisplayOrder { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
    }
}