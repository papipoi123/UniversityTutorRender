using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Ratings)
                   .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.TeachingCourse)
                   .WithMany(x => x.Ratings)
                   .HasForeignKey(x => x.TeachingCourseId);
        }
    }
}
