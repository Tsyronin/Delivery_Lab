using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryLab.Models
{
    public class LabContext: DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ProductTag> ProductsTags { get; set; }

        public LabContext(DbContextOptions<LabContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
