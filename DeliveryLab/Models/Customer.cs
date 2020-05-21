using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryLab.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "This field must not be empty")]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "This field must not be empty")]
        [MaxLength(50)]
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
