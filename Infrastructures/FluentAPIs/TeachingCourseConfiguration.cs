using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructures.FluentAPIs
{
    public class TeachingCourseConfiguration : IEntityTypeConfiguration<TeachingCourse>
    {
        public void Configure(EntityTypeBuilder<TeachingCourse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CoursePrice)
                   .HasColumnType("money");

            builder.HasOne(x => x.Tutor)
                   .WithMany(x => x.TeachingCourses)
                   .HasForeignKey(x => x.TutorId);

            builder.HasOne(x => x.CourseMajor)
                   .WithMany(x => x.TeachingCourses)
                   .HasForeignKey(x => x.CourseMajorId);

            builder.HasOne(x => x.University)
                   .WithMany(x => x.TeachingCourses)
                   .HasForeignKey(x => x.UniversityId);
        }
    }
}
