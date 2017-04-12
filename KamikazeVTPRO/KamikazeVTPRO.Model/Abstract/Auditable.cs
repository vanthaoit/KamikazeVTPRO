using System;
using System.ComponentModel.DataAnnotations;

namespace KamikazeVTPRO.Model.Abstract
{
    public abstract class Auditable : IAuditable,ISeoable,IUsable
    {
        public DateTime? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }

        [MaxLength(256)]
        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }
    }

}