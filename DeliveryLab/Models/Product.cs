using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryLab.Models
{
    public class Product
    {
        public Product()
        {
            ProductsTags = new List<ProductTag>();
            Orders = new List<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "This field must not be empty")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Dish")]
        [Required(ErrorMessage = "This field must not be empty")]
        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<ProductTag> ProductsTags { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
