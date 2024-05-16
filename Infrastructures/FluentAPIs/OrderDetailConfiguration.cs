using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.TeachingCourseId });

            builder.Ignore(i => i.Id);

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.OrderDetails)
                   .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.TeachingCourse)
                   .WithMany(x => x.OrderDetails)
                   .HasForeignKey(x => x.TeachingCourseId);
        }
    }
}
