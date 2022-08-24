using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebsiteBanGiay.Context;
using WebsiteBanGiay.Models;

namespace WebsiteBanGiay.Context
{
    [MetadataType(typeof(ProductMasterData))]
    public partial class SanPham
    {

        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(CategoryMasterData))]
    public partial class Category
    {

        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}