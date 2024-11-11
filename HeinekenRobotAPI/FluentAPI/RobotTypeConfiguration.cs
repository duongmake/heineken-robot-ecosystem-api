using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class RobotTypeConfiguration : IEntityTypeConfiguration<RobotType>
    {
        public void Configure(EntityTypeBuilder<RobotType> builder)
        {
            builder.ToTable("RobotType");
            builder.HasKey(x => x.RobotTypeId);
            builder.Property(x => x.RobotTypeName).IsRequired();

            builder.HasMany(x => x.Robots).WithOne(x => x.RobotType).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
