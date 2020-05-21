using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryLab.Models
{
    public class ProductTag
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "This field must not be empty")]
        public int ProductId { get; set; }

        [Display(Name = "Tag")]
        [Required(ErrorMessage = "This field must not be empty")]
        public int TagId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
