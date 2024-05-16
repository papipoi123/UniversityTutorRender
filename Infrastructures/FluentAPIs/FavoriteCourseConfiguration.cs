using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class FavoriteCourseConfiguration : IEntityTypeConfiguration<FavoriteCourse>
    {
        public void Configure(EntityTypeBuilder<FavoriteCourse> builder)
        {
            builder.HasKey(x => new { x.TeachingCourseId, x.StudentId });

            builder.Ignore(x => x.Id);

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.FavoriteCourses)
                   .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.TeachingCourse)
                   .WithMany(x => x.FavoriteCourses)
                   .HasForeignKey(x => x.TeachingCourseId);
        }
    }
}
