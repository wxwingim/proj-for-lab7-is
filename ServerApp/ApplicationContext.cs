using Microsoft.EntityFrameworkCore;
using DataBaseEntities;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ServerApp
{
    public class ApplicationContext: DbContext
    {

        public DbSet<Inventory> Inventories { get; set; } = null;
        public DbSet<Item> Items { get; set; } = null;

        public ApplicationContext(DbContextOptions options) : base(options) { }
        public ApplicationContext() : base() {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}