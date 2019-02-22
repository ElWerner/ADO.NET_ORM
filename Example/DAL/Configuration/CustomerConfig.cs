using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class CustomerConfig : EntityTypeConfiguration<Customer>
    {
        public CustomerConfig()
        {
            this.ToTable("tbl_customers").HasKey(customer => customer.Id);
            this.Property(customer => customer.Id).HasColumnName("cln_customer_id");
            this.Property(customer => customer.Name).HasColumnName("cln_customer_name");
            this.Property(customer => customer.Address).HasColumnName("cln_customer_address");
            this.Property(customer => customer.City).HasColumnName("cln_customer_city");
            this.Property(customer => customer.State).HasColumnName("cln_customer_state");

            /*this.HasMany<Order>(c => c.Orders)
                .WithRequired(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);*/
        }
    }
}
