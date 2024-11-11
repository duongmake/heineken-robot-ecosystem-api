using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class CampaignRobotMachineConfiguration : IEntityTypeConfiguration<CampaignRobotMachine>
    {
        public void Configure(EntityTypeBuilder<CampaignRobotMachine> builder)
        {
            builder.ToTable("CampaignRobotMachine");
            builder.HasKey(x => x.CampaignRobotMachineId);
            builder.Property(x => x.AssignedDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();

        }
    }
}
