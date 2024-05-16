using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class OnlineClassConfiguration : IEntityTypeConfiguration<OnlineClass>
    {
        public void Configure(EntityTypeBuilder<OnlineClass> builder)
        {
            builder.HasKey(x => new { x.TeachingCourseId, x.StudentId});

            builder.Ignore(x => x.Id);

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.OnlineClasses)
                   .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.TeachingCourse)
                   .WithMany(x => x.OnlineClasses)
                   .HasForeignKey(x => x.TeachingCourseId);
        }
    }
}
