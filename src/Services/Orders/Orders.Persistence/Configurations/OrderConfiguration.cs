﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Aggregate.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(o => o.UserId).IsRequired().HasColumnName("UserId");
            builder.Property(o => o.TotalAmount).IsRequired().HasColumnName("TotalAmount");
            builder.Property(o => o.TotalPrice).IsRequired().HasColumnName("TotalPrice");
            builder.Property(o => o.Status).IsRequired().HasColumnName("Status");
            builder.Property(o => o.Number).IsRequired().HasColumnName("Number");
            builder.Property(o => o.Expiry).IsRequired().HasColumnName("Expiry");
            
            builder.HasMany(o=>o.OrderItems)
                   .WithOne(oi=>oi.Order)
                   .HasForeignKey(oi=>oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
