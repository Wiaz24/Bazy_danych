using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using Bazy_danych.Models;
using System.Reflection.Emit;


namespace Bazy_danych
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DailyData> Daily { get; set; }
        public DbSet<YearlyData> Yearly { get; set; }
        //public DbSet<Favourite> Favourites { get; set; }
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

            builder.Entity<DailyData>()
                .ToTable("historia_dzienna");

            builder.Entity<YearlyData>()
                .ToTable("historia_roczna");

            //builder.Entity<Favourite>()
            //    .ToTable("historia_roczna")
            //    .HasKey(nameof(Favourite.CompanyID), nameof(Favourite.UserID));
        }
    }
}
