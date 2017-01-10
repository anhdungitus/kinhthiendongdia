using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LTHD.Domain.Models;

namespace LTHD.Mapping.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            //Primary Key
            this.HasKey(t => t.OrderId);

            //Table and Column Mapping
            this.ToTable("Order");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.TotalCost).HasColumnName("TotalCost");
            this.Property(t => t.ReceiverName).HasColumnName("ReceiverName");
            this.Property(t => t.ReceiverPhoneNumber).HasColumnName("ReceiverPhoneNumber");
            this.Property(t => t.TradeAdress).HasColumnName("TradeAdress");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.RequestDay).HasColumnName("RequestDay");
        }
    }
}
