using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");
            builder.HasKey(x => x.LocationId);
            builder.Property(x => x.LocationName).IsRequired();
            builder.Property(x => x.Latitude).IsRequired().HasPrecision(9, 6);
            builder.Property(x => x.Longitude).IsRequired().HasPrecision(9, 6);

            builder.HasMany(x => x.CampaignRobotMachines).WithOne(x => x.Location).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.RecycleMachines).WithOne(x => x.Location).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Robots).WithOne(x => x.Location).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
