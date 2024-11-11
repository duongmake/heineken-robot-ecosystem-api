using HeinekenRobotAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeinekenRobotAPI.FluentAPI
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.CustomerName).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PointsBalance).IsRequired();

            builder.HasMany(x => x.Transactions).WithOne(x => x.Customer).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
