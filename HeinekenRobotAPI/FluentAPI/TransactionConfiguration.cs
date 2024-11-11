using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(x => x.TransactionId);
            builder.Property(x => x.PointsEarned).IsRequired();
            builder.Property(x => x.TransactionDate).IsRequired();

            builder.HasOne(x => x.Campaign).WithOne()
                                           .HasForeignKey<Transaction>(x => x.CampaignId)
                                           .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Robot).WithOne()
                                        .HasForeignKey<Transaction>(x => x.RobotId)
                                        .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.RecycleMachine).WithOne()
                                                 .HasForeignKey<Transaction>(x => x.RecycleMachineId)
                                                 .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Location).WithOne()
                                           .HasForeignKey<Transaction>(x => x.LocationId)
                                           .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Gift).WithOne()
                                       .HasForeignKey<Transaction>(x => x.GiftId)
                                       .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
