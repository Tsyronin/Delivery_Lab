using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryLab.Models
{
    public class Delivery
    {
        public Delivery()
        {
            Orders = new List<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Delivery")]
        [Required(ErrorMessage = "This field must not be empty")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Display(Name = "Delivery's site")]
        [Required(ErrorMessage = "This field must not be empty")]
        [MaxLength(30)]
        public string Site { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
