using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Principal;

namespace HeinekenRobotAPI.Data
{
    public class HeinekenRobotDBContext : DbContext
    {
        public HeinekenRobotDBContext()
        {
        }

        public HeinekenRobotDBContext(DbContextOptions<HeinekenRobotDBContext> opt) : base(opt) { }

        public virtual DbSet<Campaign>? Campaigns { get; set; }
        public virtual DbSet<CampaignRobotMachine>? CampaignRobotMachines { get; set; }
        public virtual DbSet<Customer>? Customers { get; set; }
        public virtual DbSet<Gift>? Gifts { get; set; }
        public virtual DbSet<GiftRedemption>? GiftRedemptions { get; set; }
        public virtual DbSet<Location>? Locations { get; set; }
        public virtual DbSet<RecycleMachine>? RecycleMachines { get; set; }
        public virtual DbSet<Region>? Regions { get; set; }
        public virtual DbSet<RewardRule>? RewardRules { get; set; }
        public virtual DbSet<Robot>? Robots { get; set; }
        public virtual DbSet<RobotType>? RobotTypes { get; set; }
        public virtual DbSet<Transaction>? Transactions { get; set; }
        public virtual DbSet<User>? Users { get; set; }

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
