using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace webAPI.ContextFactory
{
    public class RepositoryContextFactory
        : IDesignTimeDbContextFactory<RepositoryContex>
    {
        public RepositoryContex CreateDbContext(string[] args)
        {
            // ConfigurationBuilder

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            //DbContextBuilder

            var builder = new DbContextOptionsBuilder<RepositoryContex>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                prj => prj.MigrationsAssembly("webAPI"));

            return new RepositoryContex(builder.Options);
        }
    }
}
