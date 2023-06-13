using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using Platformy_Programowania_1.Models;


namespace Platformy_Programowania_1
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Stock> Stocks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DailyData> Daily { get; set; }
        public DbSet<YearlyData> Yearly { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Order> Orders { get; set; }
        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
                .ToTable("firmy");

            builder.Entity<Order>()
                .ToTable("zamowienia");

        }
    }
}
