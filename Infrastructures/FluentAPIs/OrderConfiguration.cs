using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalPrice)
                   .HasColumnType("money");

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Tutor)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.TutorId);
        }
    }
}
