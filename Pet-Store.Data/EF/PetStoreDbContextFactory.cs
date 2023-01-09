using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pet_Store.Data.EF;

namespace HouseWarehouseStore.Data.EF
{
    public class PetStoreDbContextFactory : IDesignTimeDbContextFactory<PetStoreDbContext>
    {
        public PetStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PetStoreDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<PetStoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new PetStoreDbContext(optionsBuilder.Options);
        }
    }
}