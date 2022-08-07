using ExchangeProject.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExchangeProject.Infrastructure.Data
{
    public class CurrencyContext: DbContext
    {
        public CurrencyContext(DbContextOptions<CurrencyContext>options):base(options)
        {
            
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Exchange>Exchanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         //   modelBuilder.Entity<Exchange>().HasOne(x=>x.)
        }
    }
}
