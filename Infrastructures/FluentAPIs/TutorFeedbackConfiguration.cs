using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class TutorFeedbackConfiguration : IEntityTypeConfiguration<TutorFeedback>
    {
        public void Configure(EntityTypeBuilder<TutorFeedback> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.TutorFeedbacks)
                   .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Tutor)
                   .WithMany(x => x.TutorFeedbacks)
                   .HasForeignKey(x => x.TutorId);
        }
    }
}
