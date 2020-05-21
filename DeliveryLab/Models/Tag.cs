using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryLab.Models
{
    public class Tag
    {
        public Tag()
        {
            ProductsTags = new List<ProductTag>();
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tag")]
        [Required(ErrorMessage = "This field must not be empty")]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<ProductTag> ProductsTags { get; set; }
    }
}
