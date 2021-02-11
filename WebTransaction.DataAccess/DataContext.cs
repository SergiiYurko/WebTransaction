using Microsoft.EntityFrameworkCore;
using WebTransaction.Domain.Models;

namespace WebTransaction.DataAccess
{
    public sealed class DataContext: DbContext
    {
        public DbSet<Transaction> FileInfos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}