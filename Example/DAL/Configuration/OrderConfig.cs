using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            this.ToTable("tbl_orders").HasKey(item => item.Id);
            this.Property(item => item.Id).HasColumnName("cln_order_id");
            this.Property(item => item.Date).HasColumnName("cln_order_date");

            this.HasMany<OrderItem>(oi => oi.OrderItems)
                .WithRequired(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            this.Property(item => item.CustomerId).HasColumnName("cln_order_customer_id");
        }
    }
}