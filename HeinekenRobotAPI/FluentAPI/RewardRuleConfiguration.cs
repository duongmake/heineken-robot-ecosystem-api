using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class RewardRuleConfiguration : IEntityTypeConfiguration<RewardRule>
    {
        public void Configure(EntityTypeBuilder<RewardRule> builder)
        {
            builder.ToTable("RewardRule");
            builder.HasKey(x => x.RewardRuleId);
            builder.Property(x => x.PointRangeMin).IsRequired();
            builder.Property(x => x.PointRangeMax).IsRequired();
            builder.Property(x => x.GiftChance).IsRequired().HasPrecision(5, 2);
            builder.Property(x => x.CreateTime).IsRequired().HasPrecision(5, 2);

        }
    }
}
