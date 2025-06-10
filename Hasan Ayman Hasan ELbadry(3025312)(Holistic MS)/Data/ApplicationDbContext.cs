using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models;
using Microsoft.EntityFrameworkCore;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasIndex(x => x.AccountNumber).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankCard> BankCards{ get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
