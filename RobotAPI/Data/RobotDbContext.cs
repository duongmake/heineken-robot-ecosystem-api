using Microsoft.EntityFrameworkCore;
using RobotAPI.Entities;
using System.Reflection;
using System.Security.Principal;

namespace RobotAPI.Data
{
    public class RobotDbContext : DbContext
    {
        public RobotDbContext()
        {
        }

        public RobotDbContext(DbContextOptions<RobotDbContext> opt) : base(opt) { }

        public DbSet<Robot> Robots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:DB"]!;
        }

    }
}
