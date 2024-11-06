using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class RobotConfiguration : IEntityTypeConfiguration<Robot>
    {
        public void Configure(EntityTypeBuilder<Robot> builder)
        {
            builder.ToTable("Robot");
            builder.HasKey(x => x.RobotId);
            builder.Property(x => x.RobotCode).IsRequired();
            builder.Property(x => x.RobotType).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.BatteryLevel).IsRequired();
            builder.Property(x => x.LastAccessTime).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();



        }
    }
}
