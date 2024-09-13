using System;
using Domain.Orders;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    internal class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(li => li.Id);

            builder.Property(li => li.Id).HasConversion(lineItemId => lineItemId.Value, value => new LineItemId(value));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(li => li.ProductId);

            builder.OwnsOne(li => li.Price); // Price ı listitem  tablosunda tutar

        }
    }
}

