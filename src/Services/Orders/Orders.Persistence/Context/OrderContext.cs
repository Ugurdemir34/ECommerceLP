using Microsoft.EntityFrameworkCore;
using Orders.Domain.Aggregate.OrderAggregates;
using Orders.Domain.Aggregate.OrderAggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Persistence.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> opt) : base(opt)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                        .HasOne<Order>(oi => oi.Order)
                        .WithMany(o => o.OrderItems)
                        .HasForeignKey(oi => oi.OrderId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>().OwnsOne(o => o.Address).WithOwner();          
        }
    }
}
