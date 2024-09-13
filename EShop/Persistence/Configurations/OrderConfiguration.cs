using System;
using Microsoft.EntityFrameworkCore;
using Domain.Orders;
using Domain.Customer;

namespace Persistence.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasConversion(orderId => orderId.Value, value => new OrderId(value));

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .IsRequired();

            builder.HasMany(o => o.LineItems)
               .WithOne()
               .HasForeignKey(li => li.OrderId);

            
        }
    }
}

