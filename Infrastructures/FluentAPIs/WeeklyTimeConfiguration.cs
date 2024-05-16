using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class WeeklyTimeConfiguration : IEntityTypeConfiguration<WeeklyTime>
    {
        public void Configure(EntityTypeBuilder<WeeklyTime> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.TeachingCourse)
                   .WithMany(x => x.WeeklyTimes)
                   .HasForeignKey(x => x.TeachingCourseId);
        }
    }
}
