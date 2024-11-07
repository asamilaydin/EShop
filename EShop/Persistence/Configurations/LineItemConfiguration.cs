using System;
using Domain.Orders;
using Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(li => li.Id);

            builder.Property(li => li.Id).HasConversion(lineItemId => lineItemId.Value, value => new LineItemId(value));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(li => li.ProductId);

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(li => li.OrderId);

            builder.OwnsOne(li => li.Price);
        }
    }
}

