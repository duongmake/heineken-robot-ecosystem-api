using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RobotAPI.Entities;
using System.Security.Principal;

namespace RobotAPI.FluentAPI
{
    public class RobotConfiguration : IEntityTypeConfiguration<Robot>
    {
        public void Configure(EntityTypeBuilder<Robot> builder)
        {
            builder.ToTable("Robot");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.LastAccessTime).IsRequired();
            builder.Property(x => x.BatteryLevel).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
