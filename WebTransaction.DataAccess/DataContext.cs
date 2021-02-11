using Microsoft.EntityFrameworkCore;
using WebTransaction.Domain.Models;

namespace WebTransaction.DataAccess
{
    public sealed class DataContext: DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .Property(c => c.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}