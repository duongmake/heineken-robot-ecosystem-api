using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class GiftRedemptionConfiguration : IEntityTypeConfiguration<GiftRedemption>
    {
        public void Configure(EntityTypeBuilder<GiftRedemption> builder)
        {
            builder.ToTable("GiftRedemption");
            builder.HasKey(x => x.GiftRedemptionId);
            builder.Property(x => x.RedemptionDate).IsRequired();
            builder.Property(x => x.QrCode).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.RedeemedAt).IsRequired();

            builder.HasOne(x => x.Campaign);
            builder.HasOne(x => x.User);

        }
    }
}
