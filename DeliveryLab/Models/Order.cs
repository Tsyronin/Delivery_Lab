using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryLab.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "This field must not be empty")]
        public int ProductId { get; set; }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "This field must not be empty")]
        public int CustomerId { get; set; }

        [Display(Name = "Delivery")]
        [Required(ErrorMessage = "This field must not be empty")]
        public int DeliveryId { get; set; }

        [Display(Name = "Date and Time")]
        [Required(ErrorMessage = "This field must not be empty")]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
