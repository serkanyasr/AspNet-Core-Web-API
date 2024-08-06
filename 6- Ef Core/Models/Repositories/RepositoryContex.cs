using bsStoreApp.Models.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace bsStoreApp.Models.Repositories
{
    public class RepositoryContex: DbContext
    {
        public RepositoryContex(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
    
}
