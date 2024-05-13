using Microsoft.EntityFrameworkCore;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {

        protected override OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=...;initial Catalog=MultishopOrderDb;integrated Security=true;");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
