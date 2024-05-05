using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopApp.Discount.Entities;
using System.Data;

namespace ShopApp.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\Abdullah;initial Catalog=ShopAppDiscountDb;integrated Security=true;");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

    }
}
