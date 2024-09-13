﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Customer;


namespace Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(customerId => customerId.Value, value => new CustomerId(value));

            builder.Property(c => c.Email).HasMaxLength(255);

            builder.HasIndex(c => c.Email).IsUnique() ;

            builder.Property(c => c.Name).HasMaxLength(255);

        }
    }
}
