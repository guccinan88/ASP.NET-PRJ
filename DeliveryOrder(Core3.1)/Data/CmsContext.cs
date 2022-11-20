using Microsoft.EntityFrameworkCore;
using DeliveryOrder.Models;
namespace DeliveryOrder.Data
{
    public class CmsContext:DbContext
    {
        public CmsContext(DbContextOptions<CmsContext> options):base(options) { }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Delivery_Order> deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Com_A", Address = "台北市信義區", Email = "com_a@gmail.com", Phone = "02-123123" }
                );
            modelBuilder.Entity<Delivery_Order>().HasData(
                new Delivery_Order { Id = 1, ProductName = "Pro0001", ProductCount = 2000, Customer_Name = "Com_A", Date = new System.DateTime(2022, 01, 10).Date }
                );
        }
    }
}
