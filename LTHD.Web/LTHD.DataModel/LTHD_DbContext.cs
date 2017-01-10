using System.Data.Entity;
using LTHD.Domain.Models;
using LTHD.Mapping.Mappings;

namespace LTHD.DataModel
{
    public class LTHD_DbContext : DbContext
    {
        static LTHD_DbContext()
        {
            Database.SetInitializer<LTHD_DbContext>(null);
        }
        public LTHD_DbContext() : base("Name=LTHD_DbContext")
        {
            this.Database.CommandTimeout = 180;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OrderLineMap());
            modelBuilder.Configurations.Add(new OrderMap());
        }
    }
}
