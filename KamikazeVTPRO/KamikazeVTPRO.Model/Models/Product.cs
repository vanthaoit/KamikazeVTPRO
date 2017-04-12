using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KamikazeVTPRO.Model.Abstract;

namespace KamikazeVTPRO.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }

        public string Content { set; get; }

        public string Description { set; get; }

        [Required]
        public string CategoryID { set; get; }

        public string Image { set; get; }

        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }

        public bool? HotFlag { set; get; }

        public bool? HomeFlag { set; get; }

        public int? ViewCount { set; get; }

        public string Tags { set; get; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { set; get; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}