using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KamikazeVTPRO.Model.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [StringLength(500)]
        public string Name { set; get; }

        [StringLength(500)]
        public string Message { set; get; }

        [StringLength(500)]
        public string Email { set; get; }

        public DateTime CreateDate { set; get; }

        [Required]
        public bool Status { set; get; }
    }
}