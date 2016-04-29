using Restaurant.Core.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DataLayer
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
            : base("RestaurantConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public RestaurantDbContext(String RstConnectionString)
            : base(RstConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<FoodMenu> FoodMenu { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<SaleControl> SaleControl { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RestaurantDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
