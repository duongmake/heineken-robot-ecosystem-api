using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class RecycleMachineConfiguration : IEntityTypeConfiguration<RecycleMachine>
    {
        public void Configure(EntityTypeBuilder<RecycleMachine> builder)
        {
            builder.ToTable("RecycleMachine");
            builder.HasKey(x => x.RecycleMachineId);
            builder.Property(x => x.MachineCode).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.ContainerStatus).IsRequired();
            builder.Property(x => x.LastServiceDate).IsRequired();

            builder.HasOne(x => x.Location);
            builder.HasMany(x => x.CampaignRobotMachines).WithOne(x => x.RecycleMachine).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
