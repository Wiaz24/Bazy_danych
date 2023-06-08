using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Platformy_Programowania_1.Models;


namespace Platformy_Programowania_1
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<User> AllUsers { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
