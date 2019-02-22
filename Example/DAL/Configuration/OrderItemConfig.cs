using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class OrderItemConfig : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfig()
        {
            this.ToTable("tbl_order_items").HasKey(t => new { t.ItemId, t.OrderId });
            this.Property(oi => oi.ItemId).HasColumnName("cln_item_id");
            this.Property(oi => oi.OrderId).HasColumnName("cln_order_id");
        }
    }
}
