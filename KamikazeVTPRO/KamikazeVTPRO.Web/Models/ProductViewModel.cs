﻿using System;
using System.Collections.Generic;
using KamikazeVTPRO.Model.Models;

namespace KamikazeVTPRO.Web.Models
{
    public class ProductViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public string Description { set; get; }

        public string Content { set; get; }

        public int CategoryID { set; get; }

        public string Image { set; get; }

        public string MoreImages { set; get; }

        public bool? HomeFlag { set; get; }

        public bool? HotFlag { set; get; }

        public int? ViewCount { set; get; }

        public virtual ProductCategoryViewModel ProductCategories { set; get; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }

        public string Tags { set; get; }
    }
}