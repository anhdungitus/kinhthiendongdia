using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LTHD.Domain.Models;

namespace LTHD.Mapping.Mappings
{
    public class OrderLineMap : EntityTypeConfiguration<OrderLine>
    {
        public OrderLineMap()
        {
            //Primary Key
            this.HasKey(t => t.OrderLineId);

            //Table and Column Mapping
            this.ToTable("OrderLine");
            this.Property(t => t.OrderLineId).HasColumnName("OrderLineId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.OrderId).HasColumnName("OrderId");

            //Relationship
            this.HasRequired(t => t.Order)
                .WithMany(t => t.Lines)
                .HasForeignKey(d => d.OrderId);
        }
    }
}
