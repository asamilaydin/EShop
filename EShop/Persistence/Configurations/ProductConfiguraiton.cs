using System;
using Microsoft.EntityFrameworkCore;
using Domain.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Customer;

namespace Persistence.Configurations
{
    internal class ProductConfiguraiton : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasConversion(productId => productId.Value, value => new ProductId(value));

            builder.Property(p => p.Sku).HasConversion(sku => sku.Value, value =>  Sku.Create(value));

            builder.OwnsOne(p => p.Price , priceBuilder => { // valueobjectin (price) iki alt nesnesi olduğu için

                priceBuilder.Property(m => m.Currency).HasMaxLength(3);
            });



        }
    }
}

