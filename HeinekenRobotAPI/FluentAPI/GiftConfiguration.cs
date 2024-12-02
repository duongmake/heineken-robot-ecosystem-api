using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class GiftConfiguration : IEntityTypeConfiguration<Gift>
    {
        public void Configure(EntityTypeBuilder<Gift> builder)
        {
            builder.ToTable("Gift");
            builder.HasKey(x => x.GiftId);
            builder.Property(x => x.GiftName).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.TotalCount).IsRequired();
            builder.Property(x => x.RedeemedCount).IsRequired();
            builder.Property(x => x.ExpiredCount).IsRequired();

            builder.HasMany(x => x.RewardRules).WithOne(x => x.Gift).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.GiftRedemptions).WithOne(x => x.Gift).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
