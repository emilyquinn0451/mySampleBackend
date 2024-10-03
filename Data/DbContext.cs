
using Microsoft.EntityFrameworkCore;
using mySampleBackend.Infrastructure;
namespace mySampleBackend.Data
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
        public DbSet<FloopDbEntity> Floops { get; set; }
    }
}