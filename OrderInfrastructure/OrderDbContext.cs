using Microsoft.EntityFrameworkCore;
using OrderApplication.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfrastructure
{
    public class OrderDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "ordering";
        public OrderDbContext(DbContextOptions<OrderDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //ValueObject veri tabanında bir tablo olmayacağı için Dbset Olara tanımlanmadı:OwnedType
        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>().ToTable("Orders", DEFAULT_SCHEMA);
            //modelBuilder.Entity<OrderItem>().ToTable("OrderItems", DEFAULT_SCHEMA);
            //modelBuilder.Entity<OrderItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<Order>().OwnsOne(x => x.Address).WithOwner();
            //base.OnModelCreating(modelBuilder);
        }
    }
}
