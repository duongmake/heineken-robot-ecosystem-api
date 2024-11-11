using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region");
            builder.HasKey(x => x.RegionId);
            builder.Property(x => x.RegionName).IsRequired();
            builder.Property(x => x.Province).IsRequired();

            builder.HasMany(x => x.Locations).WithOne(x => x.Region).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
