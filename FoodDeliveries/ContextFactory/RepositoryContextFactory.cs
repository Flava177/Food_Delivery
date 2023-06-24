using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace FoodDeliveries.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build(); 
            
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration
                .GetConnectionString("DevConnection"),
                b => b.MigrationsAssembly("FoodDeliveries"));

            return new RepositoryContext(builder.Options); 
        }
    }
}
