using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaign");
            builder.HasKey(x => x.CampaignId);
            builder.Property(x => x.CampaignName).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.Region);
            builder.HasMany(x => x.CampaignRobotMachines).WithOne(x => x.Campaign).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
